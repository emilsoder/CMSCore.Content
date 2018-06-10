namespace CMSCore.Content.Api.Extensions
{
    using CMSCore.Content.Api.Authorization;
    using Microsoft.AspNetCore.Authorization;

    public static class AuthorizationExtensions
    {
        public static AuthorizationOptions SetPoliciesFromConfiguration(this AuthorizationOptions options, AUTH0 authSettings)
        {
            foreach (var role in authSettings.AUTH0_ROLES)
            {
                options.AddPolicy(role,
                    policy => policy.Requirements.Add(new HasRolePolicy(role, authSettings.AUTH0_DOMAIN)));
            }

            return options;
        }
    }
}