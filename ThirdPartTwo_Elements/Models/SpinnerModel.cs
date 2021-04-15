using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ThirdPartTwo_Elements.Annotations;

namespace ThirdPartTwo_Elements.Models
{
	public sealed class SpinnerModel : INotifyPropertyChanged
	{
		private int _countOfDots;
		private int _sizeOfDots;
		private SolidColorBrush _colourOfDots;
		private bool _clockwiseMovement;
		private double _velocity;

		public int CountOfDots
		{
			get => _countOfDots;
			set
			{
				_countOfDots = value;
				OnPropertyChanged(nameof(ColourOfDots));
			}
		}

		public int SizeOfDots
		{
			get => _sizeOfDots;
			set
			{
				_sizeOfDots = value;
				OnPropertyChanged(nameof(SizeOfDots));
			}
		}

		public SolidColorBrush ColourOfDots
		{
			get => _colourOfDots;
			set
			{
				_colourOfDots = value;
				OnPropertyChanged(nameof(ColourOfDots));
			} 
		}

		public bool ClockwiseMovement
		{
			get => _clockwiseMovement;
			set
			{
				_clockwiseMovement = value;
				OnPropertyChanged(nameof(ClockwiseMovement));
			}
		}

		public double Velocity
		{
			get => _velocity;
			set 
			{
				_velocity = value;
				OnPropertyChanged(nameof(Velocity));
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