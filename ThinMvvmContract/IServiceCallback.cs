using System.Collections.Generic;
using System.ServiceModel;

namespace Alexus.ThinMvvm.Contract
{

	public interface IServiceCallback
	{
		[OperationContract(IsOneWay = true)]
		void Event(List<ClientModelBase> events);
	}
}