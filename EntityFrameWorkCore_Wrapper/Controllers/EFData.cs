using EFWrapper_Engine.Resources.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_Wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFData : ControllerBase
    {
        //==//====> Core ==//==//====> Engine --/--/--> Resources --/--/--> Warehouse ==//==//====> Repository --/--/--> DataRepository ==//==//====> DataAccess
        //==//====> Utilities is shared among all the needed libraries . . .

        private readonly IDemoData _data;
        public EFData(IDemoData data)
        {
            _data = data;
        }
        [Authorize]
        [HttpGet,Route("GetData")]
        public async Task<string> GetData()
        {
            return await _data.GetDemoData();
        }

    }
}
