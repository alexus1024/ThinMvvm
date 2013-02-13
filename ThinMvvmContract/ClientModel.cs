using System;
using System.Runtime.Serialization;

namespace Alexus.ThinMvvm.Contract
{
	[KnownType(typeof (FirstClientModel))]
	[KnownType(typeof (SecondClientModel))]
	public abstract class ClientModelBase
	{

	}

	public class FirstClientModel : ClientModelBase
	{
		public Int32 Id { get; set; }
		public String Data { get; set; }
	}

	public class SecondClientModel : ClientModelBase
	{
		public Int32 Id { get; set; }
		public String AnotherData { get; set; }
	}
}