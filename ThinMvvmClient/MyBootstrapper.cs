using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace Alexus.ThinMvvm.Client
{
	public class Bootstrapper : UnityBootstrapper
	{

		protected override IModuleCatalog CreateModuleCatalog()
		{
			var catalog = new ModuleCatalog();
			return catalog;
		}

		protected override void ConfigureContainer()
		{
			Container.reg
		}


		// executes third
		protected override DependencyObject CreateShell()
		{
			return this.Container.Resolve<Shell>();
		}

		// executes fourth
		protected override void InitializeShell()
		{
			Application.Current.MainWindow = (Shell)this.Shell;
			Application.Current.MainWindow.Show();
		}
	}
}
