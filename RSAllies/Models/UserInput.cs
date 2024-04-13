using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models
{
    public class UserInput
    {
        [Required,StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(10)]
        public string Phone { get; set; } = string.Empty;
    }
}
