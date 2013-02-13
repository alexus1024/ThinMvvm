using System;
using System.ServiceModel;

namespace Alexus.ThinMvvm.Contract
{
	[ServiceContract(CallbackContract = typeof (IServiceCallback))]
	public interface IService
	{
		[OperationContract]
		FirstClientModel GetFirstClientModel(Int32 arg1, String arg2);

		[OperationContract]
		SecondClientModel GetSecondClientModel(DateTime arg1, String arg2);
	}
}