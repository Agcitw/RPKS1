using System.Windows;
using ThirdPartTwo_Elements.ModelViews;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.Views
{
	public partial class DialogHostElement
	{
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(RelayCommand), typeof(DialogHostElement), new UIPropertyMetadata(new RelayCommand(
				o => { })));

		private RelayCommand Command
		{
			get => (RelayCommand)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}


		private readonly DialogHostViewModel _mainDataContext;
		public DialogHostElement()
		{
			InitializeComponent();
			Loaded += OnLoad;
			_mainDataContext = new DialogHostViewModel();
			DataContext = _mainDataContext;
		}

		private void OnLoad(object sender, RoutedEventArgs e)
		{
			_mainDataContext.OpenDialogCommand = Command;
		}

	}
}