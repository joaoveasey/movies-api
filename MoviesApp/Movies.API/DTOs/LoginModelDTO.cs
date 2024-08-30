using System.ComponentModel.DataAnnotations;

namespace movies_api.DTOs;

public class LoginModelDTO
{
    [Required(ErrorMessage = "User name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
