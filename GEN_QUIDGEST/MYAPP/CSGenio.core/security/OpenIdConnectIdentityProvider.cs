using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quidgest.Persistence.GenericQuery;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Nodes;
using System.Web;

namespace GenioServer.security
{
    /* Example of External Identity Providers
     *  - GOOGLE https://developers.google.com/identity/protocols/OpenIDConnect:
     *      Authorize URI -> https://accounts.google.com/o/oauth2/v2/auth
     *      TokenEndpoint -> https://oauth2.googleapis.com/token
     *  - AzureAD https://learn.microsoft.com/en-us/entra/identity-platform/v2-protocols-oidc: 
     *      Authorize URI -> https://login.microsoftonline.com/[tennentId]/oauth2/v2.0/authorize
     *      TokenEndpoint -> https://login.microsoftonline.com/[tennentId]/oauth2/v2.0/token
     */

    public class OpenIdConnectIdentityProviderOptions
    {
        public OpenIdConnectIdentityProviderOptions(string description, string jsonOptions)
        {
            Scope = new List<String>() 
            { 
                "openid", //This is the only mandatory scope and will return a sub claim which represents a unique identifier for the authenticated user.
                "profile" //This scope value requests access to the End-User’s default profile Claims, which are: name, family_name, given_name, middle_name, nickname, preferred_username, profile, picture, website, gender, birthdate, zoneinfo, locale, and updated_at.                
            };

            if (Log.IsDebugEnabled)
                Log.Debug(string.Format("OpenID Config: {0}", jsonOptions));

            try
            {
                dynamic jsonOp = JObject.Parse(jsonOptions.Substring(jsonOptions.IndexOf("=") + 1));
                Authority = jsonOp.Authority;
                ClientId = jsonOp.ClientId;
                try
                {
                    ClientSecret = jsonOp.ClientSecret;
                    TokenEndpoint = jsonOp.TokenEndpoint;
                }
                catch 
                {
                    ClientSecret = null;
                    TokenEndpoint = null;
                }

                UserIdField = jsonOp.UserIdField;

                try
                {
                    Scopes = jsonOp.Scopes.ToObject<List<string>>();
                }
                catch { Scopes = null;}
                
                if(Scopes !=null)
                    Scope.AddRange(Scopes);
            }
            catch(Exception ex)
            {
                Log.Error(string.Format("OpenIdConnectIdentityProviderOptions: {0}", ex.Message));
                throw new Exception("Missing options! It's mandatory Authority, ClientId, ClientSecret and TokenEndpoint");
            }
        }

        /// <summary>
        /// Authority is the url used when making OpenIdConnect calls.
        /// </summary>
        [SecurityProviderOption()]
        [Description("The authorization endpoint in the provider where the user will login with his credentials")]
        public string Authority { get; set; }
        /// <summary>
        /// To obtain an Access Token, an ID Token, and optionally a Refresh Token, the RP (Client) sends a Token Request to the Token Endpoint to obtain a Token Response. More info at https://openid.net/specs/openid-connect-core-1_0.html#TokenEndpoint
        /// </summary>
        [SecurityProviderOption(optional: true)]
        [Description("Endpoint to validate the authorization token sent in the callback, and to exchange it for a user id token")]
        public string TokenEndpoint { get; set; }
        /// <summary>
        /// To obtain an Access Token, an ID Token, and optionally a Refresh Token, the RP (Client) sends a Token Request to the Token Endpoint to obtain a Token Response. More info at https://openid.net/specs/openid-connect-core-1_0.html#TokenEndpoint
        /// </summary>
        [SecurityProviderOption(optional: true)]
        [Description("Logout endpoint to clear the current user authenticated state")]
        public string LogoutEndpoint { get; set; }
        /// <summary>
        /// OAuth 2.0 Client Identifier valid at the Authorization Server.
        /// </summary>
        [SecurityProviderOption()]
        [Description("OAuth 2.0 Client Identifier valid at the Authorization Server")]
        public string ClientId { get; set; }
        // <summary>
        /// Client secret provided by the idenity provider to double check if user are authenticated successfully.
        /// </summary>
        [SecurityProviderOption()]
        [Description("Client secret provided by the identity provider used to access the TokenEndpoint")]
        public string ClientSecret { get; set; }
        /// <summary>
        /// Gets the list of permissions to request.
        /// </summary>
        [JsonIgnore]
        public List<string> Scope { get; private set; }
        /// <summary>
        /// field used to connect to a database user Ex: "email"
        /// </summary>
        [SecurityProviderOption(optional: true)]
        [Description("Name of the JWT property used to match against the user email field instead of the extenal userid")]
        public string UserIdField { get; set; }
        /// <summary>
        /// Gets the list of permissions to request (config).
        /// </summary>
        [SecurityProviderOption(optional: true)]
        [Description("List of user information properties to request")]
        public List<string> Scopes { get; set; }
    }

    [CredentialProvider(typeof(TokenCredential))]
    [Description("Establishes identity using an external OpenIdConnect provider.")]
    [DisplayName("OpenIdConnect")]
    public class OpenIdConnectIdentityProvider : BaseIdentityProvider
    {
        /// <inheritdoc/>
        public override bool HasRedirectLogin() => true;

        /// <inheritdoc/>
        public override string GetRedirectLoginUrl(string callback, string state = null)
        {
            if (String.IsNullOrEmpty(Options.Authority) || String.IsNullOrEmpty(Options.ClientId) || String.IsNullOrEmpty(callback))
                throw new Exception("It's mandatory to configure Authority, ClientId and CallbackPath options");

            var uriBuilder = new UriBuilder(Options.Authority);
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            //authorization flow
            if (!string.IsNullOrEmpty(Options.TokenEndpoint))
                parameters["response_type"] = "code";
            //implicit flow
            else
                parameters["response_type"] = "id_token";
            parameters["response_mode"] = "form_post";
            parameters["nonce"] = Guid.NewGuid().ToString("N").ToUpper();
            parameters["client_id"] = Options.ClientId;
            parameters["redirect_uri"] = callback;
            parameters["scope"] = string.Join(" ", Options.Scope);

            if (!string.IsNullOrEmpty(state))
                parameters["state"] = state;

            uriBuilder.Query = System.Web.HttpUtility.UrlDecode(parameters.ToString());

            if (Log.IsDebugEnabled)
                Log.Debug(string.Format("GetRedirectLoginUrl: {0}", uriBuilder.Uri.ToString()));

            return uriBuilder.Uri.ToString();
        }

        /// <inheritdoc/>
        public override bool RegisterExternalId(Credential credential, User user)
        {
            if (!(credential is TokenCredential tokenCredential))
                return false;

            try
            {
                string username = ValidateToken(tokenCredential);
                if(string.IsNullOrEmpty(username)) 
                    return false;

                var sp = PersistentSupport.getPersistentSupport(user.Year);

                //save data to PSW
                sp.openConnection();
                var userPsw = CSGenioApsw.search(sp, user.Codpsw, user);
                //UserId-Email matching
                if (!string.IsNullOrEmpty(Options.UserIdField))
                    userPsw.ValEmail = username;
                //External userId matching
                else
                    userPsw.ValUserid = username;
                userPsw.updateDirect(sp);
                sp.closeConnection();
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }

            return true;
        }


        [SecurityProviderOption(isJson:true)]
        public OpenIdConnectIdentityProviderOptions Options { get; set; }

        public OpenIdConnectIdentityProvider ()
        {
            var allOpenIdAuth = Configuration.Security.IdentityProviders.FindAll(x => x.Type == typeof(OpenIdConnectIdentityProvider).FullName);
            if (allOpenIdAuth.Count == 0)
                return;

            Options = new OpenIdConnectIdentityProviderOptions(allOpenIdAuth[0].Name, allOpenIdAuth[0].Config);
        }

        //Legacy mechanism so we can initialize the json options without doing it in the constructor
        //TODO: The complex options configuration format needs to be refactored!
        public void InitJsonOptions()
        {
            var ip = Configuration.Security.IdentityProviders.FirstOrDefault(x => x.Name == this.Id);
            Options = new OpenIdConnectIdentityProviderOptions(ip.Description, ip.Config);
        }



        /// <summary>
        /// Will check credentials and will find the "authenticated" user are on our application
        /// </summary>
        /// <param name="credential">Token identification to user on external provider</param>
        /// <returns>Internal Identity when user are found and success login on external provider</returns>
        public override IIdentity Authenticate(Credential credential)
        {
            if (credential is TokenCredential token)
                return Authenticate(token);

            return null;
        }

        /// <summary>
        /// Validate token with optional to make other call to external identity provider to double check authentication validity
        /// </summary>
        /// <param name="credential">Token identification to user on external provider</param>
        /// <returns>The external identity if it suceeds or null in case it fails</returns>
        private string ValidateToken(TokenCredential tokenCredential)
        {
            //Authorization Flow - Exchange the auth token for the identity token on the external service
            if (!string.IsNullOrEmpty(Options.TokenEndpoint))
            {
                if (string.IsNullOrEmpty(Options.ClientSecret))
                    return null;
                if (string.IsNullOrEmpty(tokenCredential.Auth))
                    return null;

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["grant_type"] = "authorization_code";
                    data["code"] = tokenCredential.Auth;
                    data["client_id"] = Options.ClientId;
                    data["client_secret"] = Options.ClientSecret;
                    data["redirect_uri"] = tokenCredential.OriginUrl; //HydrateURL(Options.CallbackPath);

                    try
                    {
                        var response = wb.UploadValues(Options.TokenEndpoint, "POST", data);
                        string responseInString = Encoding.UTF8.GetString(response);
                        
                        var json = JsonNode.Parse(responseInString);
                        var jwtstring = json["id_token"].GetValue<string>();
                        var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(jwtstring);
                        var ext_username = CalcExternalUsername(jwt);

                        if (Log.IsDebugEnabled)
                            Log.Debug(string.Format("ValidateToken Autorization FLow: {0}", ext_username));

                        return ext_username;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(string.Format("ValidateToken failed: {0}", ex.Message));
                        throw ex;
                    }
                }
            }
            //Implicit Flow - Trust the jwt directly sent by the authentication callback
            // This is NOT recommended, and is considered a very insecure method
            else
            {
                if (string.IsNullOrEmpty(tokenCredential.Token))
                    return null;
                var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(tokenCredential.Token);
                //TODO: we should at least validate if the JWT public key matched the authorized issuer
                var ext_username = CalcExternalUsername(jwt);
                if (Log.IsDebugEnabled)
                    Log.Debug(string.Format("ValidateToken Implicit Flow: {0}", ext_username));

                return ext_username;
            }
        }

        private string CalcExternalUsername(System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwt)
        {
            if (!string.IsNullOrEmpty(Options.UserIdField))
                return jwt.Payload[Options.UserIdField].ToString();
            else
                return jwt.Subject + "@" + jwt.Issuer;
        }

        /// <summary>
        /// Will check credentials and will find the "authenticated" user are on our application
        /// </summary>
        /// <param name="credential">Token identification to user on external provider</param>
        /// <param name="code">When not empty will double check if code returned from JWT are alright authenticated on external provider</param>
        /// <returns>Internal Identity when user are found and success login on external provider</returns>
        private IIdentity Authenticate(TokenCredential credential)
        {
            string ext_username = ValidateToken(credential);
            if (string.IsNullOrEmpty(ext_username))
                return null;

            //TODO: Extract this duplicated code in all providers with a UserService.GetUserBy[Name|Mail|UserId|PrimaryKey]
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
                    id = Authenticate(ext_username, sp);
                }
                catch (Exception ex)
                {
                    if(Log.IsDebugEnabled)
                        Log.Debug(string.Format("OpenIdConnectProvider authentication partial fail: {0}", ex.Message));
                }
                finally
                {
                    sp.closeConnection();
                }

                if (id != null)
                    break;
            }

            return id;
        }

        protected virtual IIdentity Authenticate(string ext_username, PersistentSupport sp)
        {
            try
            {
                //if the options specify an email jwt id field, then match with psw email field
                //else match with userid field                
                string psw_id_field = string.IsNullOrEmpty(Options.UserIdField) ? "userid" : "email";

                SelectQuery select = new SelectQuery()
                    .Select("psw", "status")
                    .Select("psw", "nome")
                    .From(Area.AreaPSW)
                    .Where(CriteriaSet.And().Equal("psw", psw_id_field, ext_username));

                var results = sp.executeReaderOneRow(select);
                if (results.Count < 2)
                    return null;

                int status = DBConversion.ToInteger(results[0]);
                string name = DBConversion.ToString(results[1]);

                if (status == 2)
                    return null;

                return new GenericIdentity(name);
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Authenticate: {0}", ex.Message));
                return null;
            }
        }
    }
}
