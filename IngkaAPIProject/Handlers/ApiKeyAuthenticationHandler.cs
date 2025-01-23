using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;



namespace IngkaAPIProject.Handlers

{
   
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string ApiKeyHeaderName = "X-Api-Key";
        private readonly IConfiguration _configuration;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IConfiguration configuration) // Inject IConfiguration to access appsettings
            : base(options, logger, encoder)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Retrieve the valid API key from configuration
            var validApiKey = _configuration["ApiSettings:ValidApiKey"];
            if (string.IsNullOrEmpty(validApiKey))
            {
                return Task.FromResult(AuthenticateResult.Fail("API Key is not configured."));
            }

            // Check if the API key exists in the request header and matches the configured key
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKey) || apiKey != validApiKey)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
            }

            // Create the authentication ticket
            var claims = new[] { new Claim(ClaimTypes.Name, "ApiUser") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}