using System;
using System.Windows;
using System.Windows.Input;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
	public class MessageDialogViewModel : BaseViewModel
	{
		private static MessageDialogModel _messageDialogModel =
			new(
				"test stringlooooooooooong\ntest string\ntest string\ntest string\ntest string\ntest string",
				12, Buttons.YesNo, new RelayCommand(_ => { }));

		public MessageDialogModel MessageDialogModel
		{
			get => _messageDialogModel;
			set
			{
				OnPropertyChanged(nameof(MessageDialogModel));
				_messageDialogModel = value;
			}
		}

		public ICommand OnTextAccept =>
			new RelayCommand(o => _messageDialogModel.TextInTextBlock = o as string);

		public ICommand OnButtonUp =>
			new RelayCommand(_ => _messageDialogModel.FontSize++, _ => _messageDialogModel.FontSize < 30);

		public ICommand OnButtonDown =>
			new RelayCommand(_ => _messageDialogModel.FontSize--, _ => _messageDialogModel.FontSize > 1);

		public ICommand OnButtonCommand =>
			new RelayCommand(_ => _messageDialogModel.CommandOnClick.Execute(_));


		public ICommand OnButtonsChange =>
			new RelayCommand(o =>
			{
				var caseButStr = o as string;
				Buttons b;
				switch (caseButStr)
				{
					case "Ok":
						b = Buttons.Ok;
						break;
					case "YesNo":
						b = Buttons.YesNo;
						break;
					case "OkCancel":
						b = Buttons.OkCancel;
						break;
					default:
						throw new ArgumentException();
				}

				switch (b)
				{
					case Buttons.Ok:
						_messageDialogModel.B1Visibility = Visibility.Hidden;
						_messageDialogModel.B2Visibility = Visibility.Visible;
						_messageDialogModel.TextOnB2 = "Ok";
						break;
					case Buttons.YesNo:
						_messageDialogModel.B1Visibility = Visibility.Visible;
						_messageDialogModel.B2Visibility = Visibility.Visible;
						_messageDialogModel.TextOnB1 = "Yes";
						_messageDialogModel.TextOnB2 = "No";
						break;
					case Buttons.OkCancel:
						_messageDialogModel.B1Visibility = Visibility.Visible;
						_messageDialogModel.B2Visibility = Visibility.Visible;
						_messageDialogModel.TextOnB1 = "Ok";
						_messageDialogModel.TextOnB2 = "Cancel";
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			});
	}
}