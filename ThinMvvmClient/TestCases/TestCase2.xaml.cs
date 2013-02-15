using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Practices.Unity;

namespace Alexus.ThinMvvm.Client.TestCases
{
	/// <summary>
	/// Interaction logic for TestCase2.xaml
	/// </summary>
	public partial class TestCase2 : UserControl
	{
		public TestCase2()
		{
			InitializeComponent();
		}


		[Dependency]
		public TestCase2ViewModel ViewModel
		{
			get { return (TestCase2ViewModel)DataContext; }
			set { DataContext = value; }
		}
	}
}
