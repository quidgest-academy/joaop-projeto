using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using CSGenio;
using CSGenio.framework;
using System.Linq;

namespace GenioServer.security
{

    //public class IdentityProviderRegistry
    //{
    //    public string ProviderName { get; set; }
    //    public Type CredentialClassType { get; set; }
    //    public Type ProviderClassType { get; set; }
    //}

    /// <summary>
    /// Implements the security login for the server application. All user identification and autorization
    /// services and policies are configured and abstracted here.
    /// </summary>
    public static class SecurityFactory
    {
		private class PrecondKeys
		{
			// The identity provider that validated the user credentials
			public const string IDENTITY__PROVIDER_NAME = "identity.providerName";
		}

		private class RoleProviderConfig
		{
			/// <summary>
			/// The provider
			/// </summary>
			public IRoleProvider Provider
			{
				get;
				private set;
			}

			/// <summary>
			/// The name for this provider
			/// </summary>
			public string Name
			{
				get;
				private set;
			}

			/// <summary>
			/// Pre-condition expression for use of the provider
			/// </summary>
			public string Precond
			{
				get;
				private set;
			}

			/// <summary>
			/// ctor
			/// </summary>
			/// <param name="provider">the provider</param>
			/// <param name="name">the name for this provider</param>
			/// <param name="precond">pre-condition expression for use of the provider</param>
			public RoleProviderConfig(IRoleProvider provider, string name, string precond)
			{
				Provider = provider;
				Name = name;
				Precond = precond;
			}
		}

		private class AuthenticationContext
		{
			public IIdentityProvider IdentityProviderCfg
			{
				get;
				private set;
			}

			public AuthenticationContext(IIdentityProvider identityProviderCfg)
			{
				IdentityProviderCfg = identityProviderCfg;
			}
		}

        /// <summary>
        /// The authentication algorithm to use when multiple providers are configured
        /// </summary>
        public static AuthenticationMode AuthenticationMode { get; set; }

		/// <summary>
		/// If the authentication should be recovered when it expires
		/// </summary>
		public static bool AllowAuthenticationRecovery { get; set; }

        /// <summary>
        /// The list of identity providers
        /// </summary>
		private static List<IIdentityProvider> m_idProviders = new List<IIdentityProvider>();
        /// <summary>
        /// The role provider
        /// </summary>
		private static List<RoleProviderConfig> m_roleProviders = new List<RoleProviderConfig>();

        ///// <summary>
        ///// Mapping between providers and credential types
        ///// </summary>      
        //private List<IdentityProviderRegistry> m_identityRegistry = new List<IdentityProviderRegistry>();

		public static IEnumerable<IIdentityProvider> IdentityProviderList => m_idProviders;
        public static IEnumerable<IRoleProvider> RoleProviderList => m_roleProviders.Select(i => i.Provider);

        /// <summary>
        /// Static constructor
        /// </summary>
        static SecurityFactory()
        {
			if (Configuration.Security == null)
			{
				AuthenticationMode = AuthenticationMode.AcceptOnFirstSucess;
				AllowAuthenticationRecovery = Configuration.LoginType == Configuration.LoginTypes.AD;
				if (Configuration.LoginType == Configuration.LoginTypes.PUREAD)
				{
                    m_idProviders.Add(ParseIdentityProvider(new IdentityProviderCfgEl()
					{
						Name = "ldap",
						Description = "Ldap",
						Type = typeof(LdapIdentityProvider).FullName,
						Config = "Dominio=" + Configuration.Domain
					}));
				}
				else
				{
                    m_idProviders.Add(ParseIdentityProvider(new IdentityProviderCfgEl()
                    {
                        Name = "quidgest",
                        Description = "Quidgest",
                        Type = typeof(QuidgestIdentityProvider).FullName,
                        Config = null
                    }));
				}
				m_roleProviders.Add(new RoleProviderConfig(ParseRoleProvider(new RoleProviderCfgEl()
				{
					Name = "quidgest",
					Type = typeof(QuidgestRoleProvider).FullName,
					Config = null
                })
					, "quidgest"
                    , null));
			}
			else
			{
				AuthenticationMode = Configuration.Security.AuthenticationMode;
				AllowAuthenticationRecovery = Configuration.Security.AllowAuthenticationRecovery;

				//aqui deve ir ler das configurações e inicializar a cadeia de providers
				foreach (IdentityProviderCfgEl provider in Configuration.Security.IdentityProviders)
				{
                    m_idProviders.Add(ParseIdentityProvider(provider));
				}
				foreach (RoleProviderCfgEl provider in Configuration.Security.RoleProviders)
				{
					m_roleProviders.Add(new RoleProviderConfig(ParseRoleProvider(provider), provider.Name, provider.Precond));
				}
			}
        }

		/// <summary>
		/// Instantiates a identity provider of the correct type class, and configures its options
		/// </summary>
		/// <param name="config">The configuration element</param>
		/// <returns>An instatiated Identity provider</returns>
		public static IIdentityProvider ParseIdentityProvider(IdentityProviderCfgEl config)
		{
            Type providerType = Type.GetType(config.Type);

            IIdentityProvider provider = Activator.CreateInstance(providerType) as IIdentityProvider;

            if (provider == null)
            {
                throw new NotImplementedException(config.Type + " does not implement interface GenioServer.security.IIdentityProvider");
            }

            provider.Id = config.Name;
            provider.Description = config.Description ?? "";

            if (config.Config != null)
            {
                bool needsJsonInit = false;
                string[] keyValues = config.Config.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string keyValue in keyValues)
                {
                    string key = HttpUtility.UrlDecode(keyValue.Substring(0, keyValue.IndexOf("=")));
                    string value = HttpUtility.UrlDecode(keyValue.Substring(keyValue.IndexOf("=") + 1));

                    PropertyInfo pi = providerType.GetProperty(key);
                    if (pi != null)
                    {
                        try
                        {
                            pi.SetValue(provider, Convert.ChangeType(value, pi.PropertyType, CultureInfo.InvariantCulture), null);
                        }
                        catch (InvalidCastException)
                        {
                            //json options are not convertible
                            needsJsonInit = true;
                        }
                    }
                }

                //Legacy mechanism so we can initialize the json options without doing it in the constructor
                //TODO: The complex options configuration format needs to be refactored!
                if (needsJsonInit)
                {
                    MethodInfo mi = providerType.GetMethod("InitJsonOptions");
                    mi?.Invoke(provider, null);
                }
            }
			return provider;
        }

        /// <summary>
        /// Instantiates a role provider of the correct type class, and configures its options
        /// </summary>
        /// <param name="config">The configuration element</param>
        /// <returns>An instatiated Role provider</returns>
        public static IRoleProvider ParseRoleProvider(RoleProviderCfgEl config)
        {
            Type providerType = Type.GetType(config.Type);

            IRoleProvider provider = Activator.CreateInstance(providerType) as IRoleProvider;

            if (provider == null)
            {
                throw new NotImplementedException(config.Type + " does not implement interface GenioServer.security.IRoleProvider");
            }

			if (config.Config != null)
			{
				string[] keyValues = config.Config.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string keyValue in keyValues)
				{
					string[] parts = keyValue.Split('=');
					string key = HttpUtility.UrlDecode(parts[0]);
					string value = HttpUtility.UrlDecode(parts[1]);

					PropertyInfo pi = providerType.GetProperty(key);
					if (pi != null)
					{
						pi.SetValue(provider, Convert.ChangeType(value, pi.PropertyType, CultureInfo.InvariantCulture), null);
					}
				}
			}

			return provider;
        }

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="credential">The user credentials</param>
        /// <returns>The user identity</returns>
        public static IPrincipal Authenticate(Credential credential)
        {
            IIdentity id = null;
            string error = "";
            AuthenticationContext authCtx = null;
            foreach (IIdentityProvider provider in m_idProviders)
            {
                try
                {
                    id = provider.Authenticate(credential);
                }
                catch (FrameworkException ex)
                {
                    error = ex.UserMessage;
                }
				catch(Exception ex)
                {
					error = ex.Message;
                }

                authCtx = new AuthenticationContext(provider);
                if (AuthenticationMode == AuthenticationMode.RejectOnFirstFail && id == null)
                    break;
                if (AuthenticationMode == AuthenticationMode.AcceptOnFirstSucess && id != null)
                    break;
            }

            if (id == null)
            {
                if (!string.IsNullOrEmpty(error))
                    return new ErrorPrincipal(error);

                return null;
            }

            return GetUserRoles(id, authCtx);
        }

        /// <summary>
        /// Obtains the roles for an authenticated user
        /// </summary>
        /// <param name="identity">the user identity</param>
        /// <returns>The user roles</returns>
		public static IPrincipal GetUserRoles(IIdentity identity)
		{
			return GetUserRoles(identity, null);
		}

        private static IPrincipal GetUserRoles(IIdentity identity, AuthenticationContext context)
        {
			try
			{
				RoleProviderConfig cfg = m_roleProviders.FirstOrDefault(p => SatisfyPrecond(p.Precond, identity, context));				
				return cfg.Provider.GetUserRoles(identity);
			}
			catch (Exception ex)
			{
				Log.Error($"Error in GetUserRoles principal: {ex.Message}");
				return new ErrorPrincipal(ex.Message);
			}
        }

		/// <summary>
		/// Get the user for an authenticated user
		/// </summary>
		/// <param name="identity"></param>
		/// <param name="user"></param>
		/// <param name="sp"></param>
		/// <returns></returns>
		public static CSGenio.business.CSGenioApsw GetUser(IIdentity identity,User user, CSGenio.persistence.PersistentSupport sp)
		{
			foreach (RoleProviderConfig cfg in m_roleProviders)
			{
				if (SatisfyPrecond(cfg.Precond, identity, null))
				{
					return cfg.Provider.GetUser(identity.Name, user, sp);
				}
			}
			return null;
		}

		/// <summary>
		/// Get the user by email for an authenticated user 
		/// </summary>
		/// <param name="identity"></param>
		/// <param name="email"></param>
		/// <param name="user"></param>
		/// <param name="sp"></param>
		/// <returns></returns>
		public static CSGenio.business.CSGenioApsw GetUserFromEmail(IIdentity identity,string email, User user, CSGenio.persistence.PersistentSupport sp)
		{
			foreach (RoleProviderConfig cfg in m_roleProviders)
			{
				if (SatisfyPrecond(cfg.Precond, identity, null))
				{
					return cfg.Provider.GetUserFromEmail(email, user,sp);
				}
			}
			return null;
		}


		/// <summary>
        /// Checks if the system needs to have password management features
        /// </summary>
        public static bool HasPasswordManagement()
        {
            //For now only systems with Quidgest identity provider manage passwords
            return m_idProviders.Any(x => x is QuidgestIdentityProvider);
        }

        /// <summary>
        /// Determines whether username and password authentication is enabled.
        /// </summary>
        /// <remarks>
        /// This method returns true if either QuidgestIdentityProvider or LdapIdentityProvider is present in the list of identity providers.
        /// This is used to determine if username and password authentication is enabled, assuming that either QuidgestIdentityProvider
        /// or LdapIdentityProvider supports this method of authentication.
		/// Note: This method checks for the presence of specific identity providers but does not verify the specific login mode (e.g., AD, Certificate, Username/Password) they are configured for. 
		/// 	Further checks might be necessary to determine the exact authentication mode each provider supports.
        /// </remarks>
        public static bool HasUsernameAuth()
        {
            return m_idProviders.Any(x => x.HasUsernameAuth());
        }

		/// <summary>
		/// Checks if the supplied identity satisfies the pre-condition expression
		/// </summary>
		/// <param name="identity">the user identity</param>
		/// <returns>True if the identity satisfies the pre-conditon expression, otherwise false</returns>
		private static bool SatisfyPrecond(string precond, IIdentity identity, AuthenticationContext context)
		{
			if (identity == null)
			{
				return false;
			}

			IDictionary<string, object> parsedPrecond = ParsePrecond(precond);

			bool satisfy = true;
			foreach (KeyValuePair<string, object> cond in parsedPrecond)
			{
				switch (cond.Key)
				{
					case PrecondKeys.IDENTITY__PROVIDER_NAME :
						satisfy &= cond.Value.Equals(context == null ? String.Empty : context.IdentityProviderCfg.Id);
						break;
					default:
						// ignore unknown keys
						break;
				}
			}

			return satisfy;
		}

		private static IDictionary<string, object> ParsePrecond(string precond)
		{
			IDictionary<string, object> result = new Dictionary<string, object>();

			if (!String.IsNullOrEmpty(precond))
			{
				string[] keyValues = precond.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string keyValue in keyValues)
				{
					string[] parts = keyValue.Split('=');
					string key = HttpUtility.UrlDecode(parts[0]);
					string value = HttpUtility.UrlDecode(parts[1]);

					result.Add(key, ParsePrecondValue(key, value));
				}
			}

			return result;
		}

		private static object ParsePrecondValue(string key, string value)
		{
			switch (key)
			{
				case PrecondKeys.IDENTITY__PROVIDER_NAME :
					return Convert.ToString(value);
				default:
					return value;
			}
		}

		public static bool AutoLoginGuest
		{
			get
			{
				if (Configuration.Security == null || Configuration.Security.Users == null)
				{
					return false;
				}

				UserCfgEl guest = Configuration.Security.Users.Find((x) => x.Type == UserType.Guest);
				return guest != null && guest.AutoLogin;
			}
		}

		public static bool IsGuest(string username)
		{
			if (Configuration.Security == null || Configuration.Security.Users == null)
			{
				return false;
			}

			return Configuration.Security.Users.Find((x) => x.Name == username && x.Type == UserType.Guest) != null;
		}

		public static bool IsGuest(IIdentity identity)
		{
			return IsGuest(identity.Name);
		}

		public static IPrincipal GetGuest()
		{
			if (Configuration.Security == null || Configuration.Security.Users == null)
			{
				return null;
			}

			UserCfgEl guest = Configuration.Security.Users.Find((x) => x.Type == UserType.Guest);

			if (guest == null)
			{
				return null;
			}

			return new GenericPrincipal(new GenericIdentity(guest.Name, "guest"), new string[] { "guest" });
		}
	}
}
