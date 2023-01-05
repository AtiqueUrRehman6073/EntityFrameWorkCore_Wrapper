using EFWrapper_Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EntityFrameWorkCore_Wrapper.Extensions
{
    public class JWTService: IJWTService
    {
        private readonly IConfiguration _configuration; 
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(string Name,string Email)
        {
			try
			{
                string invalidParamsCheck = Name == null || Name.Length == 0? "Provide User Name":Email == null || Email.Length == 0? "Provide Email ID ":"";
                if (invalidParamsCheck.Length > 0)
                    return invalidParamsCheck;
                var mySecret = _configuration["Jwt:Key"];
                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
                var tokenHandler = new JwtSecurityTokenHandler();
                var x = _configuration["Jwt:Issuer"];
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,Name),
                        new Claim(ClaimTypes.Email,Email),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                dynamic token = tokenHandler.CreateToken(tokenDescriptor);
                return token == null?"No Token Generated":token.RawData;
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
