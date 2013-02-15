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
	/// Interaction logic for TestCaseMasterDetail.xaml
	/// </summary>
	public partial class TestCaseMasterDetail : UserControl
	{
		public TestCaseMasterDetail()
		{
			InitializeComponent();
		}


		[Dependency]
		public TestCaseMasterDetailViewModel ViewModel
		{
			get { return (TestCaseMasterDetailViewModel)DataContext; }
			set { DataContext = value; }
		}
	}
}
