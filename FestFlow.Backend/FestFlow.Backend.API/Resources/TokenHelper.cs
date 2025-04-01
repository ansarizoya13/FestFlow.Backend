using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FestFlow.Backend.API.Resources
{
    public class TokenHelper
    {
        public static Guid GetUserIdFromClaims(string authHeader)
        {
            if (!string.IsNullOrEmpty(authHeader))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(authHeader);
                var userId = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
                
                if (string.IsNullOrEmpty(userId))
                    return Guid.Empty;

                return Guid.Parse(userId);
            }

            return Guid.Empty;
        }
    }
}
