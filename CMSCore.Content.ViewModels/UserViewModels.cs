namespace CMSCore.Content.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    #region Read

    [Orleans.Concurrency.Immutable]
    public class UserViewModel
    {
        public DateTime Created { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string Id { get; set; }
        public string IdentityUserId { get; set; }
        public string LastName { get; set; }
        public DateTime Modified { get; set; }
    }

    #endregion

    #region Write

    public class CreateUserViewModel
    {
        [Required(ErrorMessage = nameof(Email) + " is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = nameof(FirstName) + " is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = nameof(IdentityUserId) + " is required")]
        public string IdentityUserId { get; set; }

        [Required(ErrorMessage = nameof(LastName) + " is required")]
        public string LastName { get; set; }
    }

    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = nameof(Email) + " is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = nameof(FirstName) + " is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = nameof(LastName) + " is required")]
        public string LastName { get; set; }
    }

    public class DeleteUserViewModel
    {
        public DeleteUserViewModel(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static DeleteUserViewModel Initialize(string id)
        {
            return new DeleteUserViewModel(id);
        }
    }

    #endregion
}