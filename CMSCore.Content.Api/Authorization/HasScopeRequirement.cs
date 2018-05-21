namespace CMSCore.Content.Api.Authorization
{
    using System;
    using Microsoft.AspNetCore.Authorization;

    public class HasRolePolicy : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Value { get; }

        public HasRolePolicy(string scope, string issuer)
        {
            Value = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}