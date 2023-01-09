

using EFWrapper_Engine.Resources.Interfaces;
using EntityFrameWorkCore_Wrapper.Controllers;
using ERWrapper_Entities.Models;

namespace UnitTestEngine
{
    [TestClass]
    public class UnitTests
    {
        private readonly Auth _userAuth;
        public UnitTests(Auth userAuth)
        {
            _userAuth = userAuth;
        }
        [TestMethod]
        public async Task userLogin()
        {
            UserModel user = new UserModel
            {
                Name = "Ali",
                Email = "Ali@gmail.com",
                Token = "1234",
                Id = 11535,
                Password = "somerset",
                Status = 1
            };
            string response = await _userAuth.Login(user);
            bool x = false;
            if(string.Equals(response, "Account does not Exist! Please Create an Account!"))
                x = true;
            Assert.AreEqual(true, x);
        }
    }
}
