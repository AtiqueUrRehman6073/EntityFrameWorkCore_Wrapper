using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Utilities
{
    public interface IJWTService
    {
        public Task<string> GenerateToken(string Name, string Email);
    }
}
