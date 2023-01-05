using EFWrapper_Utilities;
using EntityFrameWorkCore_Wrapper.Context;
using EntityFrameWorkCore_Wrapper.Models;
using ERWrapper_Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFWrapper_Data_Access.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
    {
        private readonly Connections _connections;
        //private readonly DbContextOptions _options;
        private DemoContext _demoContext;
        public ApplicationDbContext(IConfiguration _config)
        {
            _demoContext = new DemoContext();
            _connections = new Connections();
            _connections.ConnectionString = _config.GetConnectionString("ConnectionString");
        }
        public async Task<string> UserSignup(UserModel obj)
        {
            try
            {
                var responseCheck = await _demoContext.Patients.AsNoTracking().Where(a => (a.PatientAccount == obj.Id && a.City == obj.Password)).ToArrayAsync();
                if (responseCheck.Length == 0 || responseCheck.Count() == 0)
                {
                    ///// Perform Insertion Here . . . 
                    return JsonConvert.SerializeObject(obj, Formatting.Indented);
                }
                obj = new UserModel();
                obj.Email = "UserName or email exists already . . .";
                return JsonConvert.SerializeObject(obj, Formatting.Indented);   
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
                var responseCheck = await _demoContext.Patients.AsNoTracking().Where(a => (a.PatientAccount == obj.Id && a.City == obj.Password)).ToArrayAsync();
                if (responseCheck.Length == 0 || responseCheck.Count() == 0)
                {
                    return "Empty";
                }
                return JsonConvert.SerializeObject(responseCheck, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(obj.Email = ex.Message,Formatting.Indented);
                throw;
            }
        }
        public async Task<string> GetAll()
        {
            try
            {
                List<Patient> list = new List<Patient>();
                var responseList = await _demoContext.Patients.FromSqlInterpolated($@"SELECT top(3000) * FROM Patient").AsNoTracking().ToListAsync();
                await _demoContext.DisposeAsync();
                return JsonConvert.SerializeObject(responseList, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}
