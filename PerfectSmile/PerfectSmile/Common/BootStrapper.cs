using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Views;
using PerfectSmile.Views.Module;
using PerfectSmile.Views.UserControl;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;

namespace PerfectSmile.Common
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<ILog4NetLogger, Log4NetLogger>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ILoginRepository, LoginRepository>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<PatientList>(Constant.Constant.View.PatientList);
            Container.RegisterTypeForNavigation<PatientForm>(Constant.Constant.View.PatientForm);

            //Container.<PatientForm>(Constant.Constant.View.PatientForm);

        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(PatientListModule));
            //catalog.AddModule(typeof(PatientFormModule));
        }



        protected override ILoggerFacade CreateLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            return new Log4NetLogger();
        }

    }

    public static class UnityExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container, string name)
        {
            container.RegisterType(typeof(object), typeof(T), name);
        }
    }

}
