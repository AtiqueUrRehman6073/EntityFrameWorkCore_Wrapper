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
    }
}
