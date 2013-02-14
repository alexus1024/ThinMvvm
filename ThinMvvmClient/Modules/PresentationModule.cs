using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexus.ThinMvvm.Client.View;
using Alexus.ThinMvvm.Client.ViewModel;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Alexus.ThinMvvm.Client.Modules
{
	class PresentationModule : IModule
	{
		public void Initialize()
		{
			// создать представления
			var view = ServiceLocator.Current.GetInstance<TestCasesView>();

			view.DataContext = ServiceLocator.Current.GetInstance<TestCasesViewModel>(); 
			// установить их в регионы

			ServiceLocator.Current.GetInstance<IRegionManager>().AddToRegion(RegionNames.Main, view);
		}
	}
}
