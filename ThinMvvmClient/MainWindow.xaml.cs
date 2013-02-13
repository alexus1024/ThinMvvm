using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alexus.ThinMvvmContract;

namespace ThinMvvmClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var factory = new DuplexChannelFactory<IService>(typeof (CallbackImplementation), "ClientConne");

            var channel = factory.CreateChannel();

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
