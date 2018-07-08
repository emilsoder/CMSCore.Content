namespace CMSCore.Content.Data.Models
{
    public class User : EntityBase
    {
        public User() { }

        public User(string identityUserId)
        {
            IdentityUserId = identityUserId;
        }

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string IdentityUserId { get; set; }


        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

    }
}