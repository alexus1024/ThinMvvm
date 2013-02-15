using System;
using System.Collections.Generic;
using System.Globalization;
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

		Random rnd = new Random();

		private Int32 GetIdHelper()
		{
			return _idCounter++;
		}



		public void CommandDoSomething()
		{
			var cb =  OperationContext.Current.GetCallbackChannel<IServiceCallback>();
			cb.Event(new List<ClientModelBase>() {  });
		}

		//private void OpComplete(object sender, EventArgs e)
		//{
		//	// var cb =  OperationContext.Current.GetCallbackChannel<IServiceCallback>();
		//	// cb.Event(new List<ServiceEvent>() { new ServiceEvent(), new ServiceEvent() });
		//}
		public DetailFullClientModel GetDetail(int id, string arg2)
		{
			return new DetailFullClientModel {Id = id, Data = "hi! " + arg2, Name = "name" + id};
		}

		public MasterClientModel GetMaster(int page, int pageSize)
		{
			var model = new MasterClientModel {Page = page, PageSize = pageSize};

			var details = new List<DetailClientModel>();

			for (int i = 0; i < pageSize; i++)
			{
				details.Add(new DetailClientModel()
					{
						Id = GetIdHelper(),
						Name = rnd.NextDouble().ToString(CultureInfo.InvariantCulture)
					});
			}

			model.Details = details;

			return model;
		}
	}
}