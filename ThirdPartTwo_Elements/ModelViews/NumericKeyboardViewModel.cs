using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ThirdPartTwo_Elements.Models;
using ThirdPartTwo_Elements.ModelViews.BaseLib;
using ThirdPartTwo_Elements.ModelViews.Commands;

namespace ThirdPartTwo_Elements.ModelViews
{
	public class NumericKeyboardViewModel : BaseViewModel
	{
		private static readonly List<SolidColorBrush> ListColors = new()
		{
			new SolidColorBrush(Colors.Aqua),
			new SolidColorBrush(Colors.Wheat),
			new SolidColorBrush(Colors.White),
			new SolidColorBrush(Colors.LightGreen)
		};

		private static readonly List<ICommand> ListCommands = new()
		{
			new RelayCommand(_ => { }),
			new RelayCommand(_ => MessageBox.Show("Button picked")),
			new RelayCommand(_ => MessageBox.Show("AAA"))
		};

		private static int _ind;

		private static NumericKeyboardModel _numericKeyboardModel =
			new(ListColors[new Random().Next(0, 3)], 14, 3, new RelayCommand(_ => { }));

		public NumericKeyboardModel NumericKeyboardModel
		{
			get => _numericKeyboardModel;
			set
			{
				OnPropertyChanged(nameof(NumericKeyboardModel));
				_numericKeyboardModel = value;
			}
		}

		public ICommand OnChangeStyle =>
			new RelayCommand(_ =>
			{
				if (_ind < 3) _ind++;
				NumericKeyboardModel.Brush = ListColors[new Random().Next(0, 3)];
				NumericKeyboardModel.FontSize = new Random().Next(10, 20);
				NumericKeyboardModel.Margin = new Random().Next(0, 14);
			});

		public ICommand OnChangeCommand =>
			new RelayCommand(_ => { NumericKeyboardModel.Command = ListCommands[new Random().Next(0, 2)]; });
	}
}