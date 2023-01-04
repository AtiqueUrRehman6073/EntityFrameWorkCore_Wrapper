using ERWrapper_Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Warehouse.Interfaces
{
    public interface IUserAuthService
    {
        public Task<string> UserSignup(UserModel obj);
        public Task<string> AuthorizeUser(UserModel obj);
        public Task<string> AuthenticateUser(UserModel obj);
    }
}
