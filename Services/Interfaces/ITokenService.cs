using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace movies_api.Services.Interfaces;

public interface ITokenService
{
    JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);
}
