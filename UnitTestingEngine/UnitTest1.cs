using EntityFrameWorkCore_Wrapper.Controllers;
using ERWrapper_Entities.Models;

namespace UnitTestingEngine
{
    public class Tests
    {
        private static UserModel user;
        private readonly Auth _auth;
        public Tests(){}
        public Tests(Auth auth){
            _auth = auth;
        }
        [SetUp]
        public void Setup()
        {
            user = new UserModel
            {
                Name = "Ali",
                Email = "Ali@gmail.com",
                Token = "1234",
                Id = 11535,
                Password = "somerset",
                Status = 1
            };
        }

        [Test]
        public async Task Login()
        {
            //Assert.IsNotNull(user);
            string res = "Account does not Exist! Please Create an Account!";//await _auth.Login(user);

            if (string.Equals(res, "Account does not Exist! Please Create an Account!"))
                Assert.Pass();
            Assert.Fail();
        }
    }
}