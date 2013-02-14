namespace Alexus.ThinMvvm.Client.ViewModel
{
	public class TestCasesViewModel
	{

		public TestCasesViewModel(TestCaseList cases)
		{
			Cases = cases;
		}

		public object Cases { get; private set; }
	}
}