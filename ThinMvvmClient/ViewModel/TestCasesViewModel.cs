using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using Alexus.ThinMvvm.Contract;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Alexus.ThinMvvm.Client.ViewModel
{
	public class TestCasesViewModel: ThinMvvmViewModelBase
	{
		private TestCase _currentCase;

		public TestCasesViewModel(TestCaseList cases, DuplexChannelFactory<IService> channelFactory)
			: base(channelFactory)
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
			regionManager.AddToRegion(regionName, view);
		}
	}
}