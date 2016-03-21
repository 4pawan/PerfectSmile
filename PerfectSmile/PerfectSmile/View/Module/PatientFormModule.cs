using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.View.UserControl;
using Prism.Modularity;
using Prism.Regions;

namespace PerfectSmile.View.Module
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
