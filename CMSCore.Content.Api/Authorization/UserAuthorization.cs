namespace CMSCore.Content.Api.Authorization
{
    using System.Collections.Generic;

    public class UserAuthorization
    {
        public List<string> Roles { get; set; }
        public List<string> Groups { get; set; }
        public List<string> Permissions { get; set; }
    }
}
 