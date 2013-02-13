using System.Windows;

namespace Alexus.ThinMvvm.Client
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var boot = new Bootstrapper();

			boot.Run();
		}
	}
}
