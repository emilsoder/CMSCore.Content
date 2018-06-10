namespace CMSCore.Content.Api.Extensions
{
    public class AUTH0
    {
        public string AUTH0_AUDIENCE { get; set; }
        public string AUTH0_DOMAIN { get; set; }

        public string [ ] AUTH0_ROLES { get; set; }
        public string [ ] AUTH0_PERMISSIONS { get; set; }
        public string [ ] AUTH0_SCOPES { get; set; }
    }
}