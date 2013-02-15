using System.ServiceModel;
using Alexus.ThinMvvm.Contract;

namespace Alexus.ThinMvvm.Client.TestCases
{
	public class TestCaseSimpleAcceptViewModel : ThinMvvmViewModelBase<DetailClientModel>
	{
		public TestCaseSimpleAcceptViewModel(DuplexChannelFactory<IService> channelFactory) : base(channelFactory)
		{
		}

		protected override DetailClientModel LoadModel()
		{
			return Server.GetDetail(15, "arrg");
		}
	}
}