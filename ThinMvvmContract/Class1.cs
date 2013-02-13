using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Alexus.ThinMvvm.Contract
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract]
        FirstClientModel GetFirstClientModel(Int32 arg1, String arg2);
    }

    
    public interface IServiceCallback
    {
        [OperationContract]
        void Event(List<ServiceEvent> events);
    }

    public class ServiceEvent
    {
    }

    public class FirstClientModel
    {
        public Int32 Id { get; set; }
        public String Data { get; set; }
    }
}
