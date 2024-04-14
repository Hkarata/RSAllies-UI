using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.English
{
    public class UserInput
    {
        [Required,StringLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        
        public string? Email { get; set; } = string.Empty;

        [Required, StringLength(10),Phone,Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        [Required, StringLength(20), PasswordPropertyText, Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
