using ChatApplication.Application.Settings;
using ChatApplication.webApi.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApplication.webApi.Service;

public class JWTService : IJWTService
{
    private readonly JWTSettings _configuration;

    public JWTService(IOptions<JWTSettings> jwtSettings)
    {
        _configuration = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string userName)
    {
        var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));

        var credentials = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("Id", userId.ToString()),
            new Claim("Username", userName)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration.Issuer,
            audience: _configuration.Audience[0],
            claims: claims,
            expires: DateTime.Now.AddHours(_configuration.ExpireHours),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
