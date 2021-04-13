using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using ThirdPartTwo_Elements.Annotations;
using ThirdPartTwo_Elements.Models;

namespace ThirdPartTwo_Elements.ModelViews
{
	public sealed class SpinnerViewModel : INotifyPropertyChanged
	{
		private SpinnerModel _spinnerModel = new SpinnerModel();
		
		public SpinnerModel SpinnerModel
		{
			get => _spinnerModel;
			set
			{
				_spinnerModel = value;
				OnPropertyChanged();
			}
		}

		public SpinnerViewModel()
		{
			_spinnerModel.ColourOfDots = new SolidColorBrush(Colors.LightPink);
			_spinnerModel.CountOfDots = 12;
			_spinnerModel.SizeOfDots = 4;
			_spinnerModel.ClockwiseMovement = true;
			_spinnerModel.Velocity = 1.0;
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}