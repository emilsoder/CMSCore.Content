namespace CMSCore.Content.Api.Extensions
{
    using CMSCore.Content.Api.Authorization;
    using Microsoft.AspNetCore.Authorization;

    public static class AuthorizationExtensions
    {
        public static AuthorizationOptions SetPoliciesFromConfiguration(this AuthorizationOptions options,
            IAuthenticationConfiguration authenticationConfiguration)
        {
            foreach (var role in authenticationConfiguration.AUTH0_ROLES)
            {
                options.AddPolicy(role,
                    policy => policy.Requirements.Add(new HasRolePolicy(role, authenticationConfiguration.AUTH0_DOMAIN)));
            }

            return options;
        }
    }
}