using EFWrapper_Engine.Resources.Interfaces;
using ERWrapper_Entities.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EntityFrameWorkCore_Wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUserAuth _userAuth;
        private readonly TelemetryClient _telemetryClient;
        public Auth(IUserAuth userAuth, TelemetryClient telemetryClient)
        {
            _userAuth = userAuth;
            _telemetryClient = telemetryClient;
        }
        [HttpPost, Route("signup")]
        public async Task<string> Signup(UserModel obj)
        {
            return await _userAuth.Signup(obj);
        }
        [HttpPost, Route("authorize")]
        public async Task<string> Authorize(UserModel obj)
        {
            _telemetryClient.TrackEvent("User Authorization");
            return await _userAuth.Authorize(obj);
        }
        [HttpPost,Route("login")]
        public async Task<string> Login(UserModel obj)
        {
            _telemetryClient.TrackEvent("User Login/Authentication");
            return await _userAuth.Authenticate(obj);
        }
        [Authorize]
        [HttpGet,Route("CheckAuth")]
        public async Task<string> CheckAuth()
        {
            UserModel obj = new UserModel();
            obj.Email = "User Authorized to access the API . . .";
            return JsonConvert.SerializeObject(obj,Formatting.Indented);
        }
    }
}
