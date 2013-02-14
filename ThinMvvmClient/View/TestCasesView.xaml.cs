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
using Alexus.ThinMvvm.Client.ViewModel;
using Microsoft.Practices.Unity;

namespace Alexus.ThinMvvm.Client.View
{
	/// <summary>
	/// Interaction logic for TestCasesView.xaml
	/// </summary>
	public partial class TestCasesView : UserControl
	{
		public TestCasesView()
		{
			InitializeComponent();
		}

		[Dependency]
		public TestCasesViewModel ViewModel
		{
			get { return (TestCasesViewModel) DataContext; }
			set { DataContext = value; }
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			var list = ViewModel.Cases;
		}
	}
}
