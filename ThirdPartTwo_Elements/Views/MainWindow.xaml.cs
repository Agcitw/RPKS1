using System;
using System.Windows;
using System.Windows.Controls;

namespace ThirdPartTwo_Elements.Views
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonSpinner_OnClick(object sender, RoutedEventArgs e)
		{
			DialogVm.OnTextChanged.Execute(Box.Text);
		}

		private void ButtonScroll_OnClick(object sender, RoutedEventArgs e)
		{
			MessageDialog.ButtonScroll_OnClick(sender, e);
		}

		private void ButtonMessage_OnClick(object sender, RoutedEventArgs e)
		{
			MesVm.OnTextAccept.Execute(BoxWithText.Text);
		}

		private void ComboBoxCommands_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var comboBox = (ComboBox)sender;
			var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
			var com = selectedItem.Content.ToString();
			switch (com)
			{
				case nameof(MesVm.MessageDialogModel.Nothing):
					MesVm.MessageDialogModel.CommandOnClick = MesVm.MessageDialogModel.Nothing;
					break;
				case nameof(MesVm.MessageDialogModel.DoubleText):
					MesVm.MessageDialogModel.CommandOnClick = MesVm.MessageDialogModel.DoubleText;
					break;
				case nameof(MesVm.MessageDialogModel.RemoveText):
					MesVm.MessageDialogModel.CommandOnClick = MesVm.MessageDialogModel.RemoveText;
					break;
				default:
					throw new ArgumentException();
			}
		}

		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var comboBox = (ComboBox)sender;
			var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
			var com = selectedItem.Content.ToString();
			switch (com)
			{
				case "Ok":
					MesVm.OnButtonsChange.Execute(com);
					break;
				case "YesNo":
					MesVm.OnButtonsChange.Execute(com);
					break;
				case "OkCancel":
					MesVm.OnButtonsChange.Execute(com);
					break;
				default:
					throw new ArgumentException();
			}
		}
	}
}