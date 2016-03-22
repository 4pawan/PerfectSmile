using PerfectSmile.Views.UserControl;
using Prism.Modularity;
using Prism.Regions;

namespace PerfectSmile.Views.Module
{
    public class PatientListModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public PatientListModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(PatientList));
        }
    }
}
