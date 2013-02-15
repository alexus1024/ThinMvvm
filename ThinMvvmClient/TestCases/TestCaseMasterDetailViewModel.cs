using System;
using System.ServiceModel;
using Alexus.ThinMvvm.Client.ViewModel;
using Alexus.ThinMvvm.Contract;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Alexus.ThinMvvm.Client.TestCases
{
	public class TestCaseMasterDetailViewModel : ThinMvvmViewModelBase<MasterClientModel>
	{
		private DetailClientModel _selectedDetail;

		public TestCaseMasterDetailViewModel(DuplexChannelFactory<IService> channelFactory)
			: base(channelFactory)
		{
		}

		public DetailClientModel SelectedDetail
		{
			get { return _selectedDetail; }
			set
			{
				if (Equals(value, _selectedDetail)) return;
				_selectedDetail = value;
				RaisePropertyChanged(() => SelectedDetail);
				SetDetailView();
			}
		}

		private void SetDetailView()
		{

			var view = ServiceLocator.Current.GetInstance<TestCaseSimpleAccept>();
			view.ViewModel.Model = Server.GetDetail(SelectedDetail.Id, "flkbjaflk");
			
			TestCasesViewModel.NavifateTo(RegionNames.Detail, view);

		}

		protected override MasterClientModel LoadModel()
		{
			return Server.GetMaster(1, 10);
		}


	}
}