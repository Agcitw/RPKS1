using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ThirdPartTwo_Elements.Annotations;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.Commands;
using ThirdPartTwo_Elements.Views;

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
				OnPropertyChanged(nameof(SpinnerModel));
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

		public SolidColorBrush PropColor => _spinnerModel.ColourOfDots;
		public int PropCount => _spinnerModel.CountOfDots;
		public int PropSize => _spinnerModel.SizeOfDots;
		public bool PropClock => _spinnerModel.ClockwiseMovement;
		public double PropVelocity => _spinnerModel.Velocity;

		public ICommand ButtonUpClicked =>
			new RelayCommand(_ => _spinnerModel.SizeOfDots++, o => _spinnerModel.SizeOfDots < 20);
		
		public ICommand ButtonDownClicked =>
			new RelayCommand(_ => _spinnerModel.SizeOfDots--, o => _spinnerModel.SizeOfDots > 0);

		public ICommand ButtonChangeColour =>
			new RelayCommand(_ => 
				_spinnerModel.ColourOfDots = new SolidColorBrush(Color.FromArgb(
					255,
					(byte)new Random().Next(256),
					(byte)new Random().Next(256),
					(byte)new Random().Next(256)
				)));
		
		
		
		

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}