using FestFlow.Backend.API.DTO;
using FestFlow.Backend.API.Responses;
using FestFlow.Backend.API.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FestFlow.Backend.API.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(UserResponse user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, !user.IsAdmin ? "User" : "Admin"),
                new Claim("EnrollmentNumber", user.StudenEnrollmentNumber),
                new Claim("DepartmentName", user.DepartmentName)
            };

            var produceToken = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(produceToken);

            return await Task.FromResult(token);
        }
    }
}
