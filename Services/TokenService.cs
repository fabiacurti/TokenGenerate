using System.IdentityModel.Tokens.Jwt;
using JwtBearer.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtBearer.Services;

public class TokenService
{
	public string Generate(User user)
	{
		// aqui cria a instância 
		var handle = new JwtSecurityTokenHandler();

		var key:byte[] = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

		var creditials = new SigningCredentials(
			new SymmetricSecurityKey(key),
			algorithm: SecurityAlgorithms.HmacSha256Signature)
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject= GenerateClaims(user),
			SigningCredentials = creditials,
			Expires = Datetime.UtcNow.AddHours(2),
		}
		//aqui gera um token
		var token = handler.CreateToken(tokenDescriptor);

		//gera uma string do token
		var string Token :string? = handler.WriteToken(token);

	}

	public static ClaimsIdentity GenerateClaims(User user)
    {
		var ci = new ClaimsIdentity();
		ci.AddClaim(
			new Claim(typeof:ClaimTypes.Name, value: user.Email));
		foreach(var role:string in user.Roles)
		{
			ci.AddClaim(new Claim(type: ClaimTypes.Role, value: role));
        }

		return ci;
    }
}