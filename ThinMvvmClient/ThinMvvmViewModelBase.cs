using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alexus.ThinMvvm.Contract;
using Microsoft.Practices.Prism.Modularity;

namespace Alexus.ThinMvvm.Client
{
	public class ThinMvvmViewModelBase : Microsoft.Practices.Prism.ViewModel.NotificationObject
	{
	}

	public class ThinMvvmViewModelBase<TClientModel> : ThinMvvmViewModelBase
		where TClientModel : ClientModelBase
	{
	}
}