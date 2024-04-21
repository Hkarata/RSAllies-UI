using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.Swahili;

public class SLogin
{
    [Required(ErrorMessage = "Namba ya Simu ni muhimu")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nywila ni muhimu")]
    public string Password { get; set; } = string.Empty;
}