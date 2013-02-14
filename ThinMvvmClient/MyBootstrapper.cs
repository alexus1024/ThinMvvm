using System.Windows;
using Alexus.ThinMvvm.Client.Modules;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
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
			base.ConfigureContainer();

			Container.RegisterType<PresentationModule>();

			//Container.RegisterInstance(typeof(Kernel.IServiceClient), new Kernel.ServiceClient());

		}


		// executes third
		protected override DependencyObject CreateShell()
		{
			var shell = this.Container.Resolve<Shell>();

			RegionManager.SetRegionManager(shell, Container.Resolve<IRegionManager>());
			RegionManager.UpdateRegions();

			return shell;
		}

		// executes fourth
		protected override void InitializeShell()
		{
			Application.Current.MainWindow = (Shell)this.Shell;
			Application.Current.MainWindow.Show();
		}
	}
}
