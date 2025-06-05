using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Newtonsoft.Json.Linq;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Xml;

namespace GenioServer.security
{

    public class CASIdentityProviderOptions
    {
        public CASIdentityProviderOptions(string description, string jsonOptions)
        {
            //load Options from configuracoes.xml
            Description = description;

            try
            {
                dynamic jsonOp = JObject.Parse(jsonOptions.Substring(jsonOptions.IndexOf("=") + 1));
                Authority = jsonOp.Authority; //URL to CAS server
                AttribValidation = jsonOp.AttribValidation; //Attribute from callback returned from CAS Server to validate if user exist
            }
            catch
            {
                throw new Exception("Missing options! It's mandatory Authority, ClientId, ClientSecret and TokenEndpoint");
            }
        }

        /// <summary>
        /// Used when have multiple providers to distinct them for the final user and to switch authentication code between their.
        /// </summary>
        public string Description { get; set; }
        /// <summary> 
        /// Authority are the url use when making CAS calls.
        /// </summary>
        [SecurityProviderOption()]
        [Description("Authority is the url to use when making CAS calls")]
        public string Authority { get; set; }
        /// <summary>
        /// Attribute from callback returned from CAS Server to validate if user exist
        /// </summary>
        [SecurityProviderOption()]
        [Description("Attribute from callback returned from CAS Server to validate if user exist")]
        public string AttribValidation { get; set; }
        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned. 
        /// </summary>
        public string CallbackPath { get; set; }
    }

    /// <summary>
    /// CAS protocol provider
    /// </summary>
    /// <remarks>
    /// https://jasigcas.readthedocs.io/en/latest/cas-server-documentation/protocol/CAS-Protocol-Specification.html
    /// https://apereo.github.io/cas/7.0.x/protocol/CAS-Protocol.html
    /// 
    /// For test machines use docker compose for fast setup:
    /// docker-compose.yml
    /// -------------------------------------------------------
    /// services:
    /// cas:
    /// image: apereo/cas:7.1.1
    /// container_name: casserver
    /// ports:
    ///   - "18080:18080"
    /// environment:
    ///   - SERVER_SSL_ENABLED=false
    ///   - SERVER_PORT=18080
    /// volumes:
    ///   - ./cas_config:/etc/cas
    /// -------------------------------------------------------
    /// cas_config/config/cas.properties
    /// -------------------------------------------------------
    /// cas.authn.accept.users=username::password
    /// cas.service-registry.core.init-from-json=true
    /// cas.service-registry.json.location=file:/etc/cas/services
    /// -------------------------------------------------------
    /// cas_config/services/localTest-1001.json
    /// -------------------------------------------------------
    /// {
    ///   "@class" : "org.apereo.cas.services.CasRegisteredService",
    ///   "serviceId" : "^https://localhost:5173/auth/CASLogin/Cas",
    ///   "name" : "localTest",
    ///   "id" : 1001,
    ///   "serviceTicketExpirationPolicy": {
    ///       "@class": "org.apereo.cas.services.DefaultRegisteredServiceServiceTicketExpirationPolicy",
    ///       "numberOfUses": 1,
    ///       "timeToLive": "100"
    ///     }
    /// }
    /// </remarks>

    [CredentialProvider(typeof(TokenCredential))]
    [Description("Establishes identity using Central Authentication Service protocol.")]
    [DisplayName("Central Authentication Service (CAS)")]
    public class CASIdentityProvider : BaseIdentityProvider
    {
        [SecurityProviderOption(isJson: true)]
        public CASIdentityProviderOptions Options { get; set; }

        /// <inheritdoc/>
        public override bool HasRedirectLogin() => true;

        /// <inheritdoc/>
        public override string GetRedirectLoginUrl(string callback, string state = null)
        {
            if (String.IsNullOrEmpty(Options.Authority) || String.IsNullOrEmpty(callback))
                throw new Exception("It's mandatory to configure Authority, and callbackPath options");

            var uriBuilder = new UriBuilder(Options.Authority);
            uriBuilder.Path += "/login";
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["service"] = callback;
            if (!String.IsNullOrEmpty(state))
                parameters["state"] = state;

            uriBuilder.Query = parameters.ToString();

            return uriBuilder.Uri.ToString();
        }


        public CASIdentityProvider()
        {
            var allCASAuth = Configuration.Security.IdentityProviders.FindAll(x => x.Type == typeof(CASIdentityProvider).FullName);
            if (allCASAuth.Count == 0)
                return;

            Options = new CASIdentityProviderOptions(allCASAuth[0].Name, allCASAuth[0].Config);
        }

        //Legacy mechanism so we can initialize the json options without doing it in the constructor
        //TODO: The complex options configuration format needs to be refactored!
        public void InitJsonOptions()
        {
            var ip = Configuration.Security.IdentityProviders.FirstOrDefault(x => x.Name == this.Id);
            Options = new CASIdentityProviderOptions(ip.Description, ip.Config);
        }

        /// <inheritdoc/>
        public override IIdentity Authenticate(Credential credential)
        {
            if (credential is TokenCredential token)
                return Authenticate(token);

            return null;
        }

        private IIdentity Authenticate(TokenCredential credential)
        {
            string usernameCred = "";

            if (string.IsNullOrEmpty(credential.Token))
                return null;

            //Find on response from CAS server the username
            XmlDocument xmlReturn = getResponseCAS(credential.Token, credential.OriginUrl);

            string tagname = string.IsNullOrEmpty(Options.AttribValidation) ? "user" : Options.AttribValidation;
            XmlNodeList userAttrib = xmlReturn.GetElementsByTagName("cas:" + tagname);
            if (userAttrib.Count > 0)
                usernameCred = userAttrib[0].InnerText;
            else
                return null;

            //At this moment the user is authenticated and we have to check if that user exist on database
            IList<string> anos = new List<string>(Configuration.Years);
            if (Configuration.Years.Count == 0)
                anos.Add(Configuration.DefaultYear);
                
            IIdentity id = null;
            foreach (string Qyear in anos)
            {
                PersistentSupport sp = PersistentSupport.getPersistentSupport(Qyear);
                try
                {
                    sp.openConnection();
                    id = Authenticate(usernameCred, sp);
                }
                catch { }
                finally
                {
                    if (!sp.TransactionIsClosed)
                        sp.closeConnection();
                }

                if (id != null)
                    break;
            }

            return id;
        }


        /// <summary>
        /// Method that validates the authentication of a user and returns all data related to the same
        /// https://stackoverflow.com/questions/4791794/client-to-send-soap-request-and-receive-response
        /// </summary>
        /// <param name="ticket">Validator identifier returned in the first CAS request</param>
		/// <param name="originUrl">Place of origin from which the order was placed, the CAS service validates that the ticket is valid from the place where the order was requested</param>
        /// <returns>The validation response xml with all authenticated user data</returns>
        private XmlDocument getResponseCAS(string ticket, string originUrl)
        {
            var uriVal = new UriBuilder(Options.Authority);
            uriVal.Path += "/serviceValidate";

            var param = HttpUtility.ParseQueryString(string.Empty);
            param.Add("service", originUrl);
            param.Add("ticket", ticket);
            uriVal.Query = param.ToString();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uriVal.ToString());
            webRequest.Method = "GET";

            string soapResult = "";
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            //convert response from server to xmldocument
            XmlDocument xmlCASResult = null;
            if (!string.IsNullOrEmpty(soapResult))
            {
                try
                {
                    xmlCASResult = new XmlDocument();
                    xmlCASResult.LoadXml(soapResult);
                }
                catch
                {
                    xmlCASResult = null;
                }
            }

            return xmlCASResult;
        }


        private IIdentity Authenticate(string username, PersistentSupport sp)
        {
            try
            {
                SelectQuery select = new SelectQuery()
                    .Select("psw", "status")
                    .Select("psw", "nome")
                    .From(Area.AreaPSW)
                    .Where(CriteriaSet.And().Equal("psw", "nome", username));

                var results = sp.executeReaderOneRow(select);
                if (results.Count < 2)
                    return null;

                int status = DBConversion.ToInteger(results[0]);
                string name = DBConversion.ToString(results[1]);

                if (status == 2)
                    return null;

                return new GenericIdentity(name);
            }
            catch 
            {
                return null;
            }
        }
    }
}
