using EFWrapper_Utilities;
using EntityFrameWorkCore_Wrapper.Context;
using EntityFrameWorkCore_Wrapper.Models;
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
        public async Task<string> GetAll()
        {
            try
            {
                List<Patient> list = new List<Patient>();
                //var response = _demoContext.Patients.FirstOrDefaultAsync().Result;
                //var response2 = _demoContext.Patients.AsAsyncEnumerable<Patient>();
                //var responseList = _demoContext.Patients.AsEnumerable().Take(2).ToList();
                var responseList = await _demoContext.Patients.FromSqlInterpolated($@"SELECT top(10) * FROM Patient").AsNoTracking().ToListAsync();
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
