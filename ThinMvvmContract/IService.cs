using System;
using System.ServiceModel;

namespace Alexus.ThinMvvm.Contract
{
	[ServiceContract(CallbackContract = typeof (IServiceCallback))]
	public interface IService
	{
		[OperationContract]
		DetailFullClientModel GetDetail(Int32 id, String arg2);

		[OperationContract]
		MasterClientModel GetMaster(Int32 page, Int32 pageSize);
	}
}