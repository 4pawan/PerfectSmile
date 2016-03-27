using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Views.UserControl.AutoCompleteTextBox;

namespace PerfectSmile.Test.Repository
{
    [TestClass]
    public class LoginRepositoryTest
    {
        private readonly ILoginRepository _loginRepository = new LoginRepository();
        private readonly IPatientRepository _patientRepository = new PatientRepository();


        [TestMethod]
        public void IsUserValidTest()
        {
            Assert.IsFalse(_loginRepository.IsUserValid("", "sdds"));
            Assert.IsFalse(_loginRepository.IsUserValid(null, null));
            Assert.IsTrue(_loginRepository.IsUserValid("pk", "pk"));
        }

        [TestMethod]
        public void GetAllPatient()
        {
            var aa = _patientRepository.GetAllPatient();
            Assert.IsNotNull(aa);
        }

    }
}
