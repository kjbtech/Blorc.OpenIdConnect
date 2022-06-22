# Blorc.OpenIdConnect

The right way to use OpenIdConnect on Blazor.

## Usage

1) Install Blorc.OpenIdConnect via NuGet.

2) Include `Blorc.Core/injector.js` the index.html file:

        <head>
                ...
                <script src="_content/Blorc.Core/injector.js"></script>
                ...
        </head>        
 
3) Update App.razor content like this:

        @using Microsoft.AspNetCore.Components.Authorization

        <CascadingAuthenticationState>
                <Router AppAssembly="@typeof(Program).Assembly">
                        <Found Context="routeData">
                                <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
                        </Found>
                        <NotFound>
                                <LayoutView Layout="@typeof(MainLayout)">
                                <p>Sorry, there's nothing at this address.</p>
                                </LayoutView>
                        </NotFound>
                </Router>
        </CascadingAuthenticationState>
        
4) Add the required service and update Program.cs file as follow:

        // Add access token delegating handler to registered http clients
        var baseUrl = builder.HostEnvironment.BaseAddress;
        builder.Services
            .AddHttpClient<WeatherForecastHttpClient>(client => client.BaseAddress = new Uri(baseUrl))
            .AddAccessToken();

        // Registering required services
        builder.Services.AddBlorcCore();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddBlocOpenIdConnect(
                        options =>
                        {
                                builder.Configuration.Bind("IdentityServer", options);
                        });

        var webAssemblyHost = builder.Build();

        await webAssemblyHost
                .ConfigureDocumentAsync(
                        async documentService =>
                        {
                                await documentService.InjectBlorcCoreJsAsync();
                                await documentService.InjectOpenIdConnectAsync();
                        });

        await webAssemblyHost.RunAsync();
        
5) Add a configuration file `wwwroot\appsettings.json`

> NOTE: The Authorization Code Flow with Proof Key for Code Exchange (PKCE) to the Authorization Code flow to prevent CSRF and authorization code injection attacks and it is the only supported method. Use the configuration values as shown below.
        
        {
          "IdentityServer": {
            "ResponseType": "code",
            "Scope": "openid profile %API-NAME%",
            "RedirectUri": "%APPLICATION_URL%",
            "PostLogoutRedirectUri": "%APPLICATION_URL%",
            "Authority": "%IDENTITY_SERVER_URL%",
            "ClientId": "%CLIENT_ID%",
            "AutomaticSilentRenew": true | false,
            "FilterProtocolClaims": true,
            "LoadUserInfo": true
          }
        }

6) Use the following guides as reference for identity server configuration.  

- Authorization Code flow with PKCE (Keycloak) - https://www.appsdeveloperblog.com/pkce-verification-in-authorization-code-grant/
- PKCE Verification in Authorization Code Grant (Auth0) - https://auth0.com/docs/get-started/authentication-and-authorization-flow/authorization-code-flow-with-proof-key-for-code-exchange-pkce
