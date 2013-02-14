using System.ServiceModel;
using Alexus.ThinMvvm.Contract;

namespace Alexus.ThinMvvm.Client.TestCases
{
	public class TestCase1ViewModel : ThinMvvmViewModelBase<FirstClientModel>
	{
		public TestCase1ViewModel(DuplexChannelFactory<IService> channelFactory) : base(channelFactory)
		{
		}

		protected override FirstClientModel LoadModel()
		{
			return Server.GetFirstClientModel(123, "arrg");
		}
	}
}