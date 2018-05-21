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
//{https://tojs.io/user_authorization: {"groups":["Contributors","Administrators"],"roles":["administrator","contributor"],"permissions":["manage:content"]}}