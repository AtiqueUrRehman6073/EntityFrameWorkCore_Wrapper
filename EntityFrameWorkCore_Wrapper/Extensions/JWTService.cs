using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EntityFrameWorkCore_Wrapper.Extensions
{
    public class JWTService
    {
        public async Task<string> GenerateToken(string Name,string Email)
        {
			try
			{
				string? token = "";
                var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

                var myIssuer = "http://mysite.com";
                var myAudience = "http://myaudience.com";

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,Name),
                        new Claim(ClaimTypes.Email,Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Issuer = myIssuer,
                    Audience = myAudience,
                    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                token = tokenHandler.CreateToken(tokenDescriptor).ToString();
                return token == null?"No Token Generated":token;
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
