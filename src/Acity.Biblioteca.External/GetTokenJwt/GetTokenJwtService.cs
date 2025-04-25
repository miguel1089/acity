

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Acity.Biblioteca.Application.External.GetTokenJwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Acity.Biblioteca.External.GetTokenJwt
{
    public class GetTokenJwtService: IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public string Execute(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["SecretKeyJwt"]?? string.Empty;
            var signiKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(signiKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["IssuerJwt"],
                Audience = _configuration["AudienceJwt"],
            };
            var token = tokenHandler.CreateToken(tokendescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
