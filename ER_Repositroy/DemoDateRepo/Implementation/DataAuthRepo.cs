using EFWrapper_Data_Access.DbContext;
using EFWrapper_Utilities;
using EntityFrameWorkCore_Wrapper.Extensions;
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
		private readonly IApplicationDbContext _context;
		private readonly IJWTService _jwtService;
		public DataAuthRepo(IApplicationDbContext context,IJWTService jWTService)
		{
			_context = context;
			_jwtService = jWTService;
		}
		public async Task<string> UserSignup(UserModel obj)
		{
			try
			{
				var dbResponse = await _context.UserAuth(obj);
                if (dbResponse != "Empty")
                {
                    return "Account already Exists! Please try another UserName or Password!";
                }
                else
				{
					string token = "";
					token = await _jwtService.GenerateToken(obj.Name, obj.Email);
					return token;
                }
			}
			catch (Exception ex)
			{
				return ex.Message;
				throw;
			}
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
