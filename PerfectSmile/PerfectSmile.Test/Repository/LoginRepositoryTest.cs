using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;

namespace PerfectSmile.Test.Repository
{
    [TestClass]
    public class LoginRepositoryTest
    {
        private readonly ILoginRepository _loginRepository = new LoginRepository();


        [TestMethod]
        public void IsUserValidTest(string name, string password)
        {
            //var asd = _loginRepository.IsUserValid("", "sdds");
            Assert.IsFalse(true);
            //Assert.IsFalse(_loginRepository.IsUserValid(null, null));
            //Assert.IsTrue(_loginRepository.IsUserValid("pk", "pk"));
        }
    }
}
