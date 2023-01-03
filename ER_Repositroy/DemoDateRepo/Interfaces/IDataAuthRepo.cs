using ERWrapper_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERWrapper_Repositroy.DemoDateRepo.Interfaces
{
    public interface IDataAuthRepo
    {
        public Task<string> UserSignup(UserModel obj);
        public Task<string> UserAuth(UserModel obj);
    }
}
