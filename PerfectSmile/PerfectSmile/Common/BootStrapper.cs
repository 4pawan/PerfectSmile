using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Unity;

namespace PerfectSmile.Common
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<View.Login>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }


        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }

    }
}
