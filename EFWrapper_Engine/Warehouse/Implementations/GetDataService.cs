using EFWrapper_Engine.Warehouse.Interfaces;
using ERWrapper_Repositroy.DemoDateRepo.Implementation;
using ERWrapper_Repositroy.DemoDateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Warehouse.Implementations
{
    public class GetDataService : IGetDataService
    {
        private readonly IDemoDataRepo _demoDataRepo;
        public GetDataService(IDemoDataRepo demoDataRepo)
        {
            _demoDataRepo = demoDataRepo;
        }
        public async Task<string> GetDemoData()
        {
            try
            {
                return await _demoDataRepo.GetDemoData();
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}
