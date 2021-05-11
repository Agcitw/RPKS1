using System.ComponentModel;
using System.Runtime.CompilerServices;
using ThirdPartTwo_Elements.Annotations;

namespace ThirdPartTwo_Elements.Models
{
	public sealed class SpinnerDialogModel : INotifyPropertyChanged
	{
		private int _fontSize;
		private string _text;

		public SpinnerDialogModel(string text, int fontSize)
		{
			_text = text;
			_fontSize = fontSize;
		}

		public string Text
		{
			get => _text;
			set
			{
				OnPropertyChanged(nameof(Text));
				_text = value;
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