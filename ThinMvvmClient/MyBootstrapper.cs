using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Alexus.ThinMvvm.Client.Modules;
using Alexus.ThinMvvm.Client.TestCases;
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
			var catalog = base.CreateModuleCatalog();
			return catalog;
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
			
		
			this.ModuleCatalog.AddModule(new ModuleInfo("TestCasesModule", typeof(TestCasesModule).AssemblyQualifiedName));

			this.ModuleCatalog.AddModule(new ModuleInfo("PresentationModule", typeof(PresentationModule).AssemblyQualifiedName));

			
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			Container.RegisterType<TestCaseList>(new ContainerControlledLifetimeManager());

			//Container.RegisterInstance(typeof(Kernel.IServiceClient), new Kernel.ServiceClient());
			
		}


		// executes third
		protected override DependencyObject CreateShell()
		{
			var shell = this.Container.Resolve<Shell>();
			var mm = this.ModuleCatalog;
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

	public class TestCaseList : ObservableCollection<TestCase>
	{
		
	}
	public class TestCase
	{
		public String View { get; set; }
		public String Title { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
