using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using Alexus.ThinMvvm.Client.Modules;
using Alexus.ThinMvvm.Contract;

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
			var m = new PresentationModule();
			m.Initialize();
		}

		

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var factory = new DuplexChannelFactory<IService>(typeof(CallbackImplementation), "ThinMvvmService");

            var cb = new InstanceContext(new CallbackImplementation());
           
            var channel = factory.CreateChannel(cb);

            channel.GetFirstClientModel(1, "Hi");
        }
    }

    public class CallbackImplementation: IServiceCallback
    {
        public void Event(List<ClientModelBase> events)
        {
            
        }
    }
}
