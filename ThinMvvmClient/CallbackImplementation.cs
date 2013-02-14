using System;
using System.Collections.Generic;
using Alexus.ThinMvvm.Contract;

namespace Alexus.ThinMvvm.Client
{
	public class CallbackImplementation: IServiceCallback
	{
		public void Event(List<ClientModelBase> events)
		{
			if(ClientModelChanged== null)
				return;
			foreach (var model in events)
			{
				ClientModelChanged(this, new ClientModelEventArgs() {Model = model});
			}
		}

		public event EventHandler<ClientModelEventArgs> ClientModelChanged;  
	}

	public class ClientModelEventArgs
	{
		public ClientModelBase Model { get; set; }
	}
}