using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Msk.Domain.Token;
using Msk.Domain.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Service.Token
{
    public class TokenService : ITokenService
    {

		private readonly IConfiguration iconfiguration;

		public TokenService(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
		}

        public TokenService()
        {
        }

        public Tokens GenerateToken(string userName)
		{
			return GenerateJWTTokens(userName);
		}

		public Tokens GenerateRefreshToken(string username)
		{
			return GenerateJWTTokens(username);
		}

		public Tokens GenerateJWTTokens(string userName)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenKey = Encoding.UTF8.GetBytes(Settings.Secret);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
				  {
				 new Claim(ClaimTypes.Name, userName)
				  }),
					Expires = DateTime.UtcNow.AddMinutes(20),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var refreshToken = GenerateRefreshToken();
				return new Tokens { Access_Token = tokenHandler.WriteToken(token), Refresh_Token = refreshToken };
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var Key = Encoding.UTF8.GetBytes(Settings.Secret);

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Key),
				ClockSkew = TimeSpan.Zero
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
			JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}


			return principal;
		}

	}

}
