using EFWrapper_Engine.Warehouse.Interfaces;
using ERWrapper_Entities.Models;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Warehouse.Implementations
{
    public class UserAuthService:IUserAuthService
    {
		private readonly IDataAuthRepo _dataAuthRepo;
		public UserAuthService(IDataAuthRepo dataAuthRepo)
		{
			_dataAuthRepo = dataAuthRepo;
		}
        public async Task<string> AuthorizeUser(UserModel obj)
        {
            try
            {
                var dbReponse = await _dataAuthRepo.UserSignup(obj);
                return dbReponse;
                //return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
        public async Task<string> AuthenticateUser(UserModel obj)
        {
			try
			{
                var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
                var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

                var myIssuer = "http://mysite.com";
                var myAudience = "http://myaudience.com";

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,obj.Name),
                        new Claim(ClaimTypes.Email,obj.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Issuer = myIssuer,
                    Audience = myAudience,
                    SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var dbReponse = await _dataAuthRepo.UserAuth(obj);
                if(dbReponse == "Empty" || dbReponse == null || dbReponse.IsNullOrEmpty() || dbReponse.Length == 0 || dbReponse.Count() == 0)
                {
                    return "Account does not Exist! Please Create an Account!";
                }
                else return dbReponse;
                //return tokenHandler.WriteToken(token);
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
