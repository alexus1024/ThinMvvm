using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Alexus.ThinMvvm.Client.ViewModel
{
	public class TestCasesViewModel: ThinMvvmViewModelBase
	{
		private TestCase _currentCase;

		public TestCasesViewModel(TestCaseList cases)
		{
			Cases = cases;
		}

		public TestCaseList Cases { get; private set; }

		public TestCase CurrentCase
		{
			get { return _currentCase; }
			set
			{
				if (Equals(value, _currentCase)) return;
				_currentCase = value;
				RaisePropertyChanged(() => CurrentCase);
				NavigateToCase(value);
			}
		}

		void NavigateToCase(TestCase target)
		{
			var view = ServiceLocator.Current.GetInstance(typeof(Object), target.View);

			var rManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			NavifateTo(RegionNames.CurrentTestCase, view);
		}

		public static void ClearRegion(string regionName)
		{
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

			foreach (var view in regionManager.Regions[regionName].Views.ToArray())
			{
				regionManager.Regions[regionName].Remove(view);
			}
		}

		public static void NavifateTo(string regionName, Object view)
		{
			ClearRegion(regionName);
			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			regionManager.AddToRegion(RegionNames.CurrentTestCase, view);
		}
	}
}