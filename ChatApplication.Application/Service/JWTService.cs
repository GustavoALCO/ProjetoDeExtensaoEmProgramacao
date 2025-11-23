using ChatApplication.Application.Interfaces;
using ChatApplication.Dommain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApplication.Application.Service;

public class JWTService : IJWTService
{
    private readonly JWTSettings _configuration;

    public JWTService(JWTSettings jwtSettings)
    {
        _configuration = jwtSettings;
    }

    public string GenerateToken(Guid userId, string userName)
    {
        var chaveScreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
        //busca a chave secreta que esta no appsetings 

        var credentials = new SigningCredentials(chaveScreta, SecurityAlgorithms.HmacSha256);
        //informa a chave o tipo de segurança para a criação do Header do JWT

        var claims = new[]
        {
                new Claim("Id", userId.ToString()),
                new Claim("Username", userName)
            };

        var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience[0],
                //Audience e o Issuer são assinaturas para que o Jwt funcione corretamente
                claims: claims,
                //claims serve para passar dados adicionais do gerador do código
                expires: DateTime.Now.AddHours(Convert.ToInt16(_configuration.ExpireHours)),
                //Define quantas horas o token vai existir
                signingCredentials: credentials
                );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
