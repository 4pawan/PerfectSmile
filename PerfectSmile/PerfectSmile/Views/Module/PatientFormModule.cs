using PerfectSmile.Views.UserControl;
using Prism.Modularity;
using Prism.Regions;

namespace PerfectSmile.Views.Module
{
    public class PatientFormModule : IModule
    {
       private readonly IRegionManager _regionManager;

        public PatientFormModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(PatientForm));
        }
    }
}
