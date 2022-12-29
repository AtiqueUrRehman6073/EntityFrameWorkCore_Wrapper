using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Warehouse.Interfaces
{
    public interface IGetDataService
    {
        public Task<string> GetDemoData();
    }
}
