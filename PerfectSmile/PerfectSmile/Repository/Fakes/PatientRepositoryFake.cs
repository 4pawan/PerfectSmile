using PerfectSmile.Repository.Abstract;
using PerfectSmile.ViewModels;
using PerfectSmile.Views;

namespace PerfectSmile.Repository.Fakes
{
    public class PatientRepositoryFake : Implementation.Repository, IPatientRepository
    {
        public int AddPatientBasicInfo(PatientBasicFormViewModel vm)
        {
            var model = Helper.Helper.ConvertToPatientModel(vm);
            TestPatientList.PatientList.Add(model);
            return 1;
        }
    }
}
