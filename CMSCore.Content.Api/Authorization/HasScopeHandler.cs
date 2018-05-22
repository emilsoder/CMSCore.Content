namespace CMSCore.Content.Api.Authorization
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Newtonsoft.Json;

    public class HasRolePolicyHandler : AuthorizationHandler<HasRolePolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasRolePolicy policy)
        {
            var obj = AuthorizeExtensions.GetUserAuthorization(context.User);
            if (obj == null) return Task.CompletedTask;

            if (obj.Roles.Contains(policy.Value))
            {
                context.Succeed(policy);
            }

            return Task.CompletedTask;
        }
    }

    public static class AuthorizeExtensions
    {
        public static UserAuthorization GetUserAuthorization(ClaimsPrincipal claimsPrincipal)
        {
            var roles = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "https://tojs.io/user_authorization");

            return roles?.Value != null
                ? JsonConvert.DeserializeObject<UserAuthorization>(roles.Value)
                : null;
        }
    }
}