﻿using EFWrapper_Engine.Resources.Interfaces;
using ERWrapper_Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_Wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUserAuth _userAuth;
        public Auth(IUserAuth userAuth)
        {
            _userAuth = userAuth;
        }
        [HttpPost, Route("authorize")]
        public async Task<string> Authorize(UserModel obj)
        {
            return await _userAuth.Authorize(obj);
        }
        [HttpPost,Route("login")]
        public async Task<string> Login(UserModel obj)
        {
            return await _userAuth.Authenticate(obj);
        }
    }
}