using ERWrapper_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Resources.Interfaces
{
    public interface IUserAuth
    {
        public Task<string> Signup(UserModel obj);
        public Task<string> Authorize(UserModel obj);
        public Task<string> Authenticate(UserModel obj);
    }
}
