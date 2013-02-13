using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
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
        public void Event(List<ServiceEvent> events)
        {
            
        }
    }
}
