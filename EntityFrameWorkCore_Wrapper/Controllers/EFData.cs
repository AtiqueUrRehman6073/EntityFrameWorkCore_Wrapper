using EFWrapper_Engine.Resources.Interfaces;
using Microsoft.ApplicationInsights;
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
        private TelemetryClient _telemetry;
        public EFData(IDemoData data, TelemetryClient telemetry)
        {
            _telemetry = telemetry;
            _data = data;
        }
        [Authorize]
        [HttpGet,Route("GetData")]
        public async Task<string> GetData()
        {
            _telemetry.TrackEvent("Get All Patient Data");
            return await _data.GetDemoData();
        }

    }
}
