using EFWrapper_Data_Access.DbContext;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERWrapper_Repositroy.DemoDateRepo.Implementation
{
    public class DemoDataRepo:IDemoDataRepo
    {
		private readonly IApplicationDbContext _context;
		public DemoDataRepo(IApplicationDbContext context)
		{
			_context = context;	
		}
        public async Task<string> GetDemoData()
        {
			try
			{
				return await _context.GetAll();
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
        }
    }
}
