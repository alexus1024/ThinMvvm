using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Alexus.ThinMvvm.Contract;

namespace Alexus.ThinMvvm.Server
{
	public class Service1 : IService
	{
		private static Int32 _idCounter = 0;

		private Int32 GetIdHelper()
		{
			return _idCounter++;
		}

		public FirstClientModel GetFirstClientModel(int arg1, string arg2)
		{
			//OperationContext.Current.OperationCompleted += OpComplete;


			return new FirstClientModel() {Id = GetIdHelper(), Data = "Hi!"};
		}

		public SecondClientModel GetSecondClientModel(DateTime arg1, string arg2)
		{
			return new SecondClientModel() {Id = GetIdHelper(), AnotherData = "data..."};
		}

		public void CommandDoSomething()
		{
			var cb =  OperationContext.Current.GetCallbackChannel<IServiceCallback>();
			cb.Event(new List<ClientModelBase>() { new FirstClientModel(), new SecondClientModel() });
		}

		//private void OpComplete(object sender, EventArgs e)
		//{
		//	// var cb =  OperationContext.Current.GetCallbackChannel<IServiceCallback>();
		//	// cb.Event(new List<ServiceEvent>() { new ServiceEvent(), new ServiceEvent() });
		//}
	}
}