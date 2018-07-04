namespace CMSCore.Content.Api.Authorization
{
    using Microsoft.Extensions.Configuration;

    public class AuthenticationConfiguration : IAuthenticationConfiguration
    { 
        public AuthenticationConfiguration(IConfiguration configuration)
        {
             configuration.GetSection("AUTH0").Bind(this);
        }

        public string AUTH0_AUDIENCE { get; set; }
        public string AUTH0_DOMAIN { get; set; }

        public string [ ] AUTH0_ROLES { get; set; }
        public string [ ] AUTH0_PERMISSIONS { get; set; }
        public string [ ] AUTH0_SCOPES { get; set; }
    }
}