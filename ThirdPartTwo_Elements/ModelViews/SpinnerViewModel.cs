using System;
using System.Windows.Input;
using System.Windows.Media;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
	public sealed class SpinnerViewModel : BaseViewModel
	{
		private static SpinnerModel _spinnerModel = new();

		public SpinnerViewModel()
		{
			_spinnerModel.ColourOfDots = new SolidColorBrush(Colors.Coral);
			_spinnerModel.CountOfDots = 12;
			_spinnerModel.SizeOfDots = 4;
			_spinnerModel.ClockwiseMovement = true;
			_spinnerModel.Velocity = 1.0;
		}

		public SpinnerModel SpinnerModel
		{
			get => _spinnerModel;
			set
			{
				_spinnerModel = value;
				OnPropertyChanged(nameof(SpinnerModel));
			}
		}

		public ICommand ButtonUpClicked =>
			new RelayCommand(_ => _spinnerModel.SizeOfDots++, o => _spinnerModel.SizeOfDots < 20);

		public ICommand ButtonDownClicked =>
			new RelayCommand(_ => _spinnerModel.SizeOfDots--, o => _spinnerModel.SizeOfDots > 0);

		public ICommand ButtonChangeColour =>
			new RelayCommand(_ =>
				_spinnerModel.ColourOfDots = new SolidColorBrush(Color.FromArgb(
					255,
					(byte) new Random().Next(200, 256),
					(byte) new Random().Next(0, 108),
					(byte) new Random().Next(0, 256)
				))
			);
	}
}