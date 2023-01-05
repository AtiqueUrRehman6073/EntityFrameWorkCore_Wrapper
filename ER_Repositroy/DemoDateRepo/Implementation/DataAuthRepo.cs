using EFWrapper_Data_Access.DbContext;
using EFWrapper_Utilities;
using EntityFrameWorkCore_Wrapper.Extensions;
using ERWrapper_Entities.Models;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using Newtonsoft.Json;
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
				var dbResponse = await _context.UserSignup(obj);
                return dbResponse;
			}
			catch (Exception ex)
			{
                return JsonConvert.SerializeObject(obj.Email = ex.Message, Formatting.Indented);
                throw;
			}
		}
		public async Task<string> UserAuthorization(UserModel obj)
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
					obj.Token = await _jwtService.GenerateToken(obj.Name, obj.Email);
					obj.Password = "";
                    return JsonConvert.SerializeObject(obj, Formatting.Indented);
                }
			}
			catch (Exception ex)
			{
                return JsonConvert.SerializeObject(obj.Email = ex.Message, Formatting.Indented);
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
                return JsonConvert.SerializeObject(obj.Email = ex.Message, Formatting.Indented);
                throw;
			}
        }
    }
}
