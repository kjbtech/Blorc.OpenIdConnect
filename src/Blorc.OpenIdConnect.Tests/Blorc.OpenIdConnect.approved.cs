﻿[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v6.0", FrameworkDisplayName="")]
namespace Blorc.OpenIdConnect
{
    public class AccessTokenDelegatingHandler : System.Net.Http.DelegatingHandler
    {
        public AccessTokenDelegatingHandler(Blorc.OpenIdConnect.IUserManager userManager) { }
        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { }
    }
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ClaimTypeAttribute : System.Attribute
    {
        public ClaimTypeAttribute(string claimType) { }
        public string ClaimType { get; }
    }
    public class CustomizeHttpRequestMessageDelegatingHandler : System.Net.Http.DelegatingHandler
    {
        public CustomizeHttpRequestMessageDelegatingHandler(System.IServiceProvider serviceProvider, System.Func<System.IServiceProvider, System.Net.Http.HttpRequestMessage, System.Threading.Tasks.Task>? customizeRequestFunction) { }
        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { }
    }
    public static class DocumentServiceExtensions
    {
        public static System.Threading.Tasks.Task InjectOpenIdConnectAsync(this Blorc.Services.IDocumentService documentService) { }
    }
    public static class EnumerableExtensions
    {
        public static System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> AsClaims(this System.Collections.IEnumerable items, string claimType) { }
    }
    public static class HasRolesExtensions
    {
        public static bool IsInRole(this Blorc.OpenIdConnect.IHasRoles hasRoles, string role) { }
    }
    public static class HttpClientBuilderExtensions
    {
        public static void AddAccessToken(this Microsoft.Extensions.DependencyInjection.IHttpClientBuilder @this) { }
        public static void CustomizeHttpRequestMessage(this Microsoft.Extensions.DependencyInjection.IHttpClientBuilder @this, System.Func<System.IServiceProvider, System.Net.Http.HttpRequestMessage, System.Threading.Tasks.Task> customizationRequest) { }
    }
    public static class HttpClientExtensions
    {
        public static void SetBearerToken(this System.Net.Http.HttpClient @this, string token) { }
        public static void SetToken(this System.Net.Http.HttpClient @this, string scheme, string token) { }
    }
    public interface IHasRoles
    {
        System.Collections.Generic.IEnumerable<string> Roles { get; }
    }
    public interface IUserManager : System.IDisposable
    {
        event System.EventHandler<Blorc.OpenIdConnect.UserActivityEventArgs>? UserActivity;
        event System.EventHandler<Blorc.OpenIdConnect.UserInactivityEventArgs>? UserInactivity;
        System.Threading.Tasks.Task<TUser?> GetUserAsync<TUser>(bool reload = true, System.Text.Json.JsonSerializerOptions? options = null);
        System.Threading.Tasks.Task<TUser?> GetUserAsync<TUser>(System.Threading.Tasks.Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState> authenticationStateTask, System.Text.Json.JsonSerializerOptions? options = null);
        System.Threading.Tasks.Task<bool> IsAuthenticatedAsync();
        System.Threading.Tasks.Task SigninRedirectAsync(string redirectUri = "");
        System.Threading.Tasks.Task SignoutRedirectAsync();
    }
    public static class JsonElementExtensions
    {
        public static TObject? ToObject<TObject>(this System.Text.Json.JsonElement element, System.Text.Json.JsonSerializerOptions? options = null) { }
    }
    public static class ObjectExtensions
    {
        public static System.Collections.Generic.IEnumerable<System.Security.Claims.Claim> AsClaims(this object instance, string claimType = "") { }
    }
    public class OidcProviderOptions
    {
        public OidcProviderOptions() { }
        [System.Text.Json.Serialization.JsonPropertyName("accessTokenExpiringNotificationTimeInSeconds")]
        public int AccessTokenExpiringNotificationTimeInSeconds { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("authority")]
        public string? Authority { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("automaticSilentRenew")]
        public bool AutomaticSilentRenew { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("checkSessionIntervalInSeconds")]
        public int CheckSessionIntervalInSeconds { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("client_id")]
        public string? ClientId { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("filterProtocolClaims")]
        public bool FilterProtocolClaims { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("loadUserInfo")]
        public bool LoadUserInfo { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("post_logout_redirect_uri")]
        public string? PostLogoutRedirectUri { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("redirect_uri")]
        public string? RedirectUri { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("response_type")]
        public string? ResponseType { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("silent_redirect_uri")]
        public string? SilentRedirectUri { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("timeForUserInactivityAutomaticSignout")]
        public int TimeForUserInactivityAutomaticSignout { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("timeForUserInactivityNotification")]
        public int TimeForUserInactivityNotification { get; set; }
    }
    public static class OidcProviderOptionsExtensions
    {
        public static System.TimeSpan GetTimeForUserInactivityAutomaticSignout(this Blorc.OpenIdConnect.OidcProviderOptions options) { }
        public static System.TimeSpan GetTimeForUserInactivityNotification(this Blorc.OpenIdConnect.OidcProviderOptions options) { }
    }
    public class OpenIdConnectAuthenticationStateProvider : Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider
    {
        public OpenIdConnectAuthenticationStateProvider(Blorc.OpenIdConnect.IUserManager userManager) { }
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState> GetAuthenticationStateAsync() { }
    }
    public static class OpenIdConnectResources
    {
        public const string DefaultSilentRefresh = "silent-refresh.html";
        public static string GetDefaultSilentRefreshPage(string baseUrl) { }
    }
    public class Profile
    {
        public Profile() { }
        [Blorc.OpenIdConnect.ClaimType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")]
        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string? Email { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }
        [Blorc.OpenIdConnect.ClaimType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")]
        [System.Text.Json.Serialization.JsonPropertyName("family_name")]
        public string? FamilyName { get; set; }
        [Blorc.OpenIdConnect.ClaimType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")]
        [System.Text.Json.Serialization.JsonPropertyName("given_name")]
        public string? GivenName { get; set; }
        [Blorc.OpenIdConnect.ClaimType("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }
        [Blorc.OpenIdConnect.ClaimType("preferred_username")]
        [System.Text.Json.Serialization.JsonPropertyName("preferred_username")]
        public string? PreferredUsername { get; set; }
        [Blorc.OpenIdConnect.ClaimType("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")]
        [System.Text.Json.Serialization.JsonPropertyName("roles")]
        public string[]? Roles { get; set; }
    }
    public static class ServiceCollectionExtensions
    {
        public static void AddBlorcOpenIdConnect(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Blorc.OpenIdConnect.OidcProviderOptions>? configure = null) { }
    }
    public static class TypeExtensions
    {
        public static bool IsPrimitiveEx(this System.Type type) { }
    }
    public class UserActivityEventArgs
    {
        public UserActivityEventArgs(System.DateTime inactivityStartTime, System.DateTime inactivityEndTime) { }
        public System.DateTime InactivityEndTime { get; }
        public System.DateTime InactivityStartTime { get; }
        public bool ResetTime { get; set; }
    }
    public class UserInactivityEventArgs
    {
        public UserInactivityEventArgs(System.TimeSpan signoutTimeSpan) { }
        public System.TimeSpan? InactivityNotificationTimeSpan { get; set; }
        public System.TimeSpan SignoutTimeSpan { get; }
    }
    public class UserManager : Blorc.OpenIdConnect.IUserManager, System.IDisposable
    {
        public UserManager(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.AspNetCore.Components.NavigationManager navigationManager, Blorc.OpenIdConnect.OidcProviderOptions options) { }
        public event System.EventHandler<Blorc.OpenIdConnect.UserActivityEventArgs>? UserActivity;
        public event System.EventHandler<Blorc.OpenIdConnect.UserInactivityEventArgs>? UserInactivity;
        public virtual void Dispose() { }
        public System.Threading.Tasks.Task<TUser?> GetUserAsync<TUser>(bool reload = true, System.Text.Json.JsonSerializerOptions? options = null) { }
        public System.Threading.Tasks.Task<TUser?> GetUserAsync<TUser>(System.Threading.Tasks.Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState> authenticationStateTask, System.Text.Json.JsonSerializerOptions? options = null) { }
        public System.Threading.Tasks.Task InitializeAsync(System.Func<System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, System.Text.Json.JsonElement>>> configurationResolver) { }
        public System.Threading.Tasks.Task<bool> IsAuthenticatedAsync() { }
        [Microsoft.JSInterop.JSInvokable]
        public void OnUserActivity() { }
        [Microsoft.JSInterop.JSInvokable]
        public double OnUserInactivity() { }
        protected virtual void RaiseUserActivity(Blorc.OpenIdConnect.UserActivityEventArgs e) { }
        protected virtual void RaiseUserInactivity(Blorc.OpenIdConnect.UserInactivityEventArgs e) { }
        public System.Threading.Tasks.Task SigninRedirectAsync(string redirectUri = "") { }
        public System.Threading.Tasks.Task SignoutRedirectAsync() { }
    }
    public static class UserManagerExtensions
    {
        public static System.Threading.Tasks.Task<Blorc.OpenIdConnect.User<Blorc.OpenIdConnect.Profile>?> GetUserAsync(this Blorc.OpenIdConnect.IUserManager userManager) { }
        public static System.Threading.Tasks.Task<Blorc.OpenIdConnect.User<Blorc.OpenIdConnect.Profile>?> GetUserAsync(this Blorc.OpenIdConnect.IUserManager userManager, System.Threading.Tasks.Task<Microsoft.AspNetCore.Components.Authorization.AuthenticationState> authenticationStateTask, System.Text.Json.JsonSerializerOptions? options = null) { }
    }
    public class User<TProfile> : Blorc.OpenIdConnect.IHasRoles
        where TProfile : Blorc.OpenIdConnect.Profile
    {
        public User() { }
        [System.Text.Json.Serialization.JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("expires_at")]
        public long ExpiresAt { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("profile")]
        public TProfile Profile { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public System.Collections.Generic.IEnumerable<string> Roles { get; }
        [System.Text.Json.Serialization.JsonPropertyName("session_state")]
        public string? SessionState { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
    }
}