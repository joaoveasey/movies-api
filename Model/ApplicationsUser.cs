using Microsoft.AspNetCore.Identity;

namespace movies_api.Model;

public class ApplicationsUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
