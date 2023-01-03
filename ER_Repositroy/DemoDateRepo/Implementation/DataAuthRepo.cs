using EFWrapper_Data_Access.DbContext;
using ERWrapper_Entities.Models;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERWrapper_Repositroy.DemoDateRepo.Implementation
{
    public class DataAuthRepo:IDataAuthRepo
    {
		private IApplicationDbContext _context;
		public DataAuthRepo(IApplicationDbContext context)
		{
			_context = context;
		}
        public async Task<string> UserAuth(UserModel obj)
        {
			try
			{
				return await _context.UserAuth(obj);
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
