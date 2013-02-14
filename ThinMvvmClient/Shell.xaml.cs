using System.ServiceModel;
using System.Windows;
using Alexus.ThinMvvm.Client.Modules;
using Alexus.ThinMvvm.Contract;
using Microsoft.Practices.ServiceLocation;

namespace Alexus.ThinMvvm.Client
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();


			Loaded += Shell_Loaded;
        }

		void Shell_Loaded(object sender, RoutedEventArgs e)
		{
			var m = ServiceLocator.Current.GetInstance<PresentationModule>();
			m.Initialize();
		}

    }
}
