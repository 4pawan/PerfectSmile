using Prism.Modularity;
using Prism.Regions;

namespace PerfectSmile.Views.Module
{
    public class PatientBasicFormModule : IModule
    {
       private readonly IRegionManager _regionManager;

        public PatientBasicFormModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Constant.Constant.View.PatientBasicForm, typeof(PatientBasicForm));
        }
    }
}
