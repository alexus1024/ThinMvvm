using System;
using System.ServiceModel;
using Alexus.ThinMvvm.Contract;

namespace Alexus.ThinMvvm.Client.TestCases
{
	public class TestCase2ViewModel : ThinMvvmViewModelBase<SecondClientModel>
	{
		public TestCase2ViewModel(DuplexChannelFactory<IService> channelFactory)
			: base(channelFactory)
		{
		}

		protected override SecondClientModel LoadModel()
		{
			return Server.GetSecondClientModel(DateTime.Now, "238572198592");
		}


	}
}