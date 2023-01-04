using ERWrapper_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Data_Access.DbContext
{
    public interface IApplicationDbContext
    {
        public Task<string> GetAll();
        public Task<string> UserSignup(UserModel obj);
        public Task<string> UserAuth(UserModel obj);
    }
}
