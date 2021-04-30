using System.Windows;
using ThirdPartTwo_Elements.ModelViews;

namespace ThirdPartTwo_Elements.Views
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			SpinnerDialogViewModel.OnTextChanged.Execute(Box.Text);
		}
	}
}