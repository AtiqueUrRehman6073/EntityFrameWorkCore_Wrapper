using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Resources.Interfaces
{
    public interface IDemoData
    {
        public Task<string> GetDemoData();
    }
}
