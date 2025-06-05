using CSGenio.framework;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace GenioServer.security
{
    /// <summary>
    /// Common interface for authentication providers
    /// </summary>
    public interface IIdentityProvider
    {
        /// <summary>
        /// Unique identifier for this provider
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// User readable title for this provider
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="credential">The user credentials</param>
        /// <returns>The user identity</returns>
        IIdentity Authenticate(Credential credential);

        /// <summary>
        /// Determines whether username and password authentication is enabled.
        /// </summary>
        /// <remarks>
        /// This is used to determine if username and password authentication is enabled.
        /// Note: This method checks for the presence of specific identity providers but does not verify the specific login mode (e.g., AD, Certificate, Username/Password) they are configured for. 
        /// 	Further checks might be necessary to determine the exact authentication mode each provider supports.
        /// </remarks>
        bool HasUsernameAuth();

        /// <summary>
        /// Determines if this provider requires the user to be redirected to an external page to authenticate before generating credentials.
        /// Call method <see cref="GetRedirectLoginUrl"/> to calculate the external endpoint.
        /// </summary>
        /// <returns></returns>
        bool HasRedirectLogin();

        /// <summary>
        /// Calculate the external endpoint to redirect the user to login
        /// </summary>
        /// <param name="callback">The internal callback endpoint the external login will call on success</param>
        /// <param name="state">Optional opaque state to send to the provider, that is supposed to be reflected to the callback</param>
        /// <returns>The fully formed login uri</returns>
        string GetRedirectLoginUrl(string callback, string state = null);

        /// <summary>
        /// If the external provider supports it, a endpoint to redirect the user to logout
        /// </summary>
        /// <param name="callback">The page the logout will return to uppon success</param>
        /// <param name="state">Optional opaque state to send to the provider, that is supposed to be reflected to the callback</param>
        /// <returns>The fully formed logout uri</returns>
        string GetRedirectLogoutUrl(string callback, string state = null);

        /// <summary>
        /// Extracts the external unique id from the credential and saves it to the internal user.
        /// If the credential is invalid or the user is inconsistent the method should fail.
        /// </summary>
        /// <param name="credential">The credential to associate</param>
        /// <param name="user">The user where the credential will be associated</param>
        /// <returns>True if the registration is sucessfull, false otherwise</returns>
        bool RegisterExternalId(Credential credential, User user);
    }

    /// <summary>
    /// Abstract default implementation for IIdentityProvider.
    /// </summary>
    public abstract class BaseIdentityProvider : IIdentityProvider
    {
        /// <inheritdoc/>
        public virtual string Id { get; set; }

        /// <inheritdoc/>
        public virtual string Description { get; set; }

        /// <inheritdoc/>
        public virtual bool HasRedirectLogin() => false;

        /// <inheritdoc/>
        public virtual string GetRedirectLoginUrl(string callback, string state = null) => "";

        /// <inheritdoc/>
        public virtual string GetRedirectLogoutUrl(string callback, string state = null) => "";

        /// <inheritdoc/>
        public virtual bool RegisterExternalId(Credential credential, User user) => true;

        /// <inheritdoc/>
        public virtual bool HasUsernameAuth() => false;

        /// <inheritdoc/>
        public abstract IIdentity Authenticate(Credential credential);
    }

    /// <summary>
    /// Declares that the class attached can handle authentication of a Credential type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CredentialProviderAttribute : Attribute
    {
        /// <summary>
        /// The Credential type
        /// </summary>
        public Type CredentialType { get; set; }

        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="credentialType">The Credential type</param>
        public CredentialProviderAttribute(Type credentialType)
        {
            this.CredentialType = credentialType;
        }
    }

    /// <summary>
    /// Marks a property of a Security provider as user defined
    /// This allows the UI to present an adequate editor for this property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SecurityProviderOptionAttribute : Attribute
    {
        /// <summary>
        /// Optional property, default is mandatory
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// This property is saved as a complex object json that requires further parsing
        /// </summary>
        public bool IsJson { get; set; }

        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="optional">Optional property, default is mandatory</param>
        public SecurityProviderOptionAttribute(bool optional=false, bool isJson=false)
        {
            Optional = optional;
            IsJson = isJson;
        }
    }

}
