using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Alexus.ThinMvvm.Contract
{
	[KnownType(typeof(MasterClientModel))]
	[KnownType(typeof(DetailClientModel))]
	public abstract class ClientModelBase
	{

	}

	public class MasterClientModel : ClientModelBase
	{
		public Int32 Page { get; set; }
		public Int32 PageSize { get; set; }
		
		public List<DetailClientModel> Details { get; set; }
	}

	public class DetailClientModel : ClientModelBase
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
	}

	public class DetailFullClientModel : DetailClientModel
	{
		public String Data { get; set; }
	}
}