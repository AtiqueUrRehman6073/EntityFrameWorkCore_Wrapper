using EFWrapper_Engine.Resources.Interfaces;
using EFWrapper_Engine.Warehouse.Interfaces;
using ERWrapper_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWrapper_Engine.Resources.Implementation
{
    public class UserAuth : IUserAuth
    {
        private readonly IUserAuthService _userAuthService;
        public UserAuth(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        public async Task<string> Signup(UserModel obj)
        {
            try
            {
                return await _userAuthService.UserSignup(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
        public async Task<string> Authorize(UserModel obj)
        {
            try
            {
                return await _userAuthService.AuthorizeUser(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
        public async Task<string> Authenticate(UserModel obj)
        {
            try
            {
                return await _userAuthService.AuthenticateUser(obj);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}
