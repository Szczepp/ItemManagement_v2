using System.ComponentModel.DataAnnotations;

namespace ItemManagement_v2.ViewModels
{
    public class ApplicationUserEdit
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Username can't be blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Invalid address email")]
        public string Email { get; set; }
    }
}
