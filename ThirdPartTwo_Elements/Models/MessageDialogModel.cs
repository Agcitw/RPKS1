using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ThirdPartTwo_Elements.Annotations;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.Models
{
	public enum Buttons
	{
		Ok,
		YesNo,
		OkCancel
	}

	public sealed class MessageDialogModel : INotifyPropertyChanged
	{
		private static string _textInTextBlock;
		public readonly ICommand DoubleText = new RelayCommand(_ => _textInTextBlock += _textInTextBlock);

		public readonly ICommand Nothing = new RelayCommand(_ => { });
		public readonly ICommand RemoveText = new RelayCommand(_ => _textInTextBlock = string.Empty);
		private Visibility _b1Visibility = Visibility.Visible;
		private Visibility _b2Visibility = Visibility.Visible;
		private Buttons _buttons;
		private ICommand _commandOnClick;
		private int _fontSize;

		private string _textOnB1 = "Yes";
		private string _textOnB2 = "No";

		public MessageDialogModel(string textInTextBlock, int fontSize, Buttons buttons, ICommand commandOnClick)
		{
			_textInTextBlock = textInTextBlock;
			_fontSize = fontSize;
			_buttons = buttons;
			_commandOnClick = commandOnClick;
		}

		public string TextInTextBlock
		{
			get => _textInTextBlock;
			set
			{
				OnPropertyChanged(nameof(TextInTextBlock));
				_textInTextBlock = value;
			}
		}

		public int FontSize
		{
			get => _fontSize;
			set
			{
				OnPropertyChanged(nameof(FontSize));
				_fontSize = value;
			}
		}

		public Buttons Buttons
		{
			get => _buttons;
			set
			{
				OnPropertyChanged(nameof(Buttons));
				_buttons = value;
			}
		}

		public ICommand CommandOnClick
		{
			get => _commandOnClick;
			set
			{
				OnPropertyChanged(nameof(CommandOnClick));
				_commandOnClick = value;
			}
		}

		public string TextOnB1
		{
			get => _textOnB1;
			set
			{
				OnPropertyChanged(nameof(TextOnB1));
				_textOnB1 = value;
			}
		}

		public string TextOnB2
		{
			get => _textOnB2;
			set
			{
				OnPropertyChanged(nameof(TextOnB2));
				_textOnB2 = value;
			}
		}

		public Visibility B1Visibility
		{
			get => _b1Visibility;
			set
			{
				OnPropertyChanged(nameof(B1Visibility));
				_b1Visibility = value;
			}
		}

		public Visibility B2Visibility
		{
			get => _b2Visibility;
			set
			{
				OnPropertyChanged(nameof(B2Visibility));
				_b2Visibility = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}