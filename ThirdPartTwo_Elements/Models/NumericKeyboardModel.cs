using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using ThirdPartTwo_Elements.Annotations;

namespace ThirdPartTwo_Elements.Models
{
	public sealed class NumericKeyboardModel : INotifyPropertyChanged
	{
		private SolidColorBrush _brush;
		private ICommand _command;
		private int _fontSize;
		private int _margin;

		public NumericKeyboardModel(SolidColorBrush brush, int fontSize, int margin, ICommand command)
		{
			_brush = brush;
			_fontSize = fontSize;
			_margin = margin;
			_command = command;
		}

		public ICommand Command
		{
			get => _command;
			set
			{
				OnPropertyChanged(nameof(Command));
				_command = value;
			}
		}

		public int Margin
		{
			get => _margin;
			set
			{
				OnPropertyChanged(nameof(Margin));
				_margin = value;
			}
		}

		public SolidColorBrush Brush
		{
			get => _brush;
			set
			{
				OnPropertyChanged(nameof(Brush));
				_brush = value;
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

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}