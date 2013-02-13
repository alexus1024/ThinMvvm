using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace Alexus.ThinMvvm.Client
{
    public class Bootstrapper : UnityBootstrapper
    {

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            return catalog;
        }

        protected override DependencyObject CreateShell()
        {
            Shell shell = Container.TryResolve<Shell>();

            Application.Current.MainWindow = shell;
			shell.Show();

            return shell;
        }
    }
}
