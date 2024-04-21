using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.English
{
    public class UserInput
    {
        [Required, StringLength(20, MinimumLength = 0), Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(20, MinimumLength = 0), Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        [Required, StringLength(10, MinimumLength = 10, ErrorMessage = "Please provide phone number with 10 digits only"), Phone, Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required, StringLength(12, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 12 characters"), PasswordPropertyText, Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
