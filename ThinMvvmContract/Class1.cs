using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Alexus.ThinMvvmContract
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        FirstClientModel GetFirstClientModel(Int32 arg1, String arg2);
    }

    public interface IServiceCallback
    {
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
