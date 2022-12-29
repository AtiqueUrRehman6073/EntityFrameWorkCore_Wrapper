using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERWrapper_Repositroy.DemoDateRepo.Interfaces
{
    public interface IDemoDataRepo
    {
        public Task<string> GetDemoData();
    }
}
