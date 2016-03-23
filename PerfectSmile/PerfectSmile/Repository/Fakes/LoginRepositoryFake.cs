using PerfectSmile.Repository.Abstract;
namespace PerfectSmile.Repository.Fakes
{

    public class LoginRepositoryFake : Implementation.Repository, ILoginRepository
    {

        public bool IsUserValid(string name, string password)
        {
            return true;
        }
    }
}
