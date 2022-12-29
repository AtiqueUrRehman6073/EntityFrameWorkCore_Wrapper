using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Data_Access.DbContext
{
    public class ApplicationDbContext:IApplicationDbContext
    {
        public async Task<string> GetAll()
        {
			try
			{
				return "All Layers Working Successfully . . . ";
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
