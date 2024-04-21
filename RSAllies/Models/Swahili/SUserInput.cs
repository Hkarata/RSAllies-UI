using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.Swahili;

public class SUserInput
{
    [Required(ErrorMessage = "Jina la Kwanza ni muhimu"), StringLength(20, MinimumLength = 0)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Jina la Mwisho ni muhimu"), StringLength(20, MinimumLength = 0)]
    public string LastName { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Namba ya Simu ni muhimu"), StringLength(10, MinimumLength = 10, ErrorMessage = "Andika namba ya simu kwa usahihi"), Phone]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nywila ni muhimu"), StringLength(12, ErrorMessage = "date za herufi ziwe kati ya 8 na 12", MinimumLength = 5), PasswordPropertyText, Display(Name = "Password")]
    public string Password { get; set; } = string.Empty;
}