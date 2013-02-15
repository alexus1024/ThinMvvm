using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Alexus.ThinMvvm.Contract;
using Microsoft.Practices.Prism.Modularity;

namespace Alexus.ThinMvvm.Client
{
	/// <summary>
	///  Идея в том, что каждая VM получаетт от сервера модель строго определённого типа. После получения сервер уведомляет VM о том, что моедль обновлиась.
	///  Сервер учитывает то, с какими параметрами моедль была получена.
	/// Тоесть, если одна VM показывает данные по вчерашнему дню, а другая - по сегодняшнему, при обновлении данных по сегодняшнему дню сервер обновит только вторую VM
	/// </summary>

	public abstract class ThinMvvmViewModelBase : Microsoft.Practices.Prism.ViewModel.NotificationObject
	{
		private readonly DuplexChannelFactory<IService> _channelFactory;
		private IService _channel;

		protected ThinMvvmViewModelBase(DuplexChannelFactory<IService> channelFactory)
		{
			_channelFactory = channelFactory;

			var cbImpl = new CallbackImplementation();
			cbImpl.ClientModelChanged += OnModelChanged; 
			var cb = new InstanceContext(cbImpl);

			var channel = _channelFactory.CreateChannel(cb);
			_channel = channel;
			//channel.GetFirstClientModel(1, "Hi");
		}

		protected abstract void OnModelChanged(object sender, ClientModelEventArgs e);
		


		protected IService Server
		{
			get { return _channel; }
		}
	}

	public abstract class ThinMvvmViewModelBase<TClientModel> : ThinMvvmViewModelBase
		where TClientModel : ClientModelBase
	{
		private TClientModel _model;

		protected ThinMvvmViewModelBase(DuplexChannelFactory<IService> channelFactory)
			: base(channelFactory)
		{
			Model = LoadModel();
		}

		protected sealed override void OnModelChanged(object sender, ClientModelEventArgs e)
		{
			if (e.Model is TClientModel)
			{
				Model = LoadModel();
			}
		}


		protected abstract TClientModel LoadModel();

		public TClientModel Model
		{
			get { return _model; }
			set
			{
				if (Equals(value, _model)) return;
				_model = value;
				RaisePropertyChanged(() => Model);
			}
		}
	}
}