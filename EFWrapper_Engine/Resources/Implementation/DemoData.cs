using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWrapper_Engine.Resources.Interfaces;
using EFWrapper_Engine.Warehouse;
using EFWrapper_Engine.Warehouse.Interfaces;

namespace EFWrapper_Engine.Resources.Implementation
{
    public class DemoData : IDemoData
    {
        private IGetDataService _getDataService;
        public DemoData(IGetDataService getDataService)
        {
            _getDataService = getDataService;
        }
        public async Task<string> GetDemoData()
        {
            return await _getDataService.GetDemoData();
        }
    }
}
