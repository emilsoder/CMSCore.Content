namespace CMSCore.Content.Api.Extensions
{
    public interface IAuthenticationConfiguration
    {
        string AUTH0_AUDIENCE { get; set; }
        string AUTH0_DOMAIN { get; set; }
        string[] AUTH0_PERMISSIONS { get; set; }
        string[] AUTH0_ROLES { get; set; }
        string[] AUTH0_SCOPES { get; set; }
    }
}