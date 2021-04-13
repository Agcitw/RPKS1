using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Third
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private readonly List<SolidColorBrush> _colorBrushesForeground = new List<SolidColorBrush>()
		{
        	new SolidColorBrush(Colors.DarkBlue),
        	new SolidColorBrush(Colors.DarkGreen),
        	new SolidColorBrush(Colors.DarkRed),
        	new SolidColorBrush(Colors.DarkOrchid)
		};
		private readonly List<SolidColorBrush> _colorBrushesBackground = new List<SolidColorBrush>()
		{
			new SolidColorBrush(Colors.LightBlue),
			new SolidColorBrush(Colors.LightGreen),
			new SolidColorBrush(Colors.LightYellow),
			new SolidColorBrush(Colors.LightCyan)
		};
		private readonly List<SolidColorBrush> _colorBrushesScroll = new List<SolidColorBrush>()
		{
			new SolidColorBrush(Colors.Green),
			new SolidColorBrush(Colors.Red),
			new SolidColorBrush(Colors.Yellow),
			new SolidColorBrush(Colors.Orange),
			new SolidColorBrush(Colors.Pink),
			new SolidColorBrush(Colors.RosyBrown),
			new SolidColorBrush(Colors.Gold),
			new SolidColorBrush(Colors.Orchid),
			new SolidColorBrush(Colors.Lime),
			new SolidColorBrush(Colors.GreenYellow),
			new SolidColorBrush(Colors.CornflowerBlue),
		};
		
		private void ButtonUp_OnClick(object sender, RoutedEventArgs e)
		{
			if (Convert.ToInt32(NumericUpDown.Text) + 1 < 31)
				NumericUpDown.Text = (Convert.ToInt32(NumericUpDown.Text) + 1).ToString();
		}
		private void ButtonDown_OnClick(object sender, RoutedEventArgs e)
		{
			if (Convert.ToInt32(NumericUpDown.Text) - 1 > 0)
				NumericUpDown.Text = (Convert.ToInt32(NumericUpDown.Text) - 1).ToString();
		}

		private void ChangeBackground_OnClick(object sender, RoutedEventArgs e)
		{
			Resources[@"ColorBrushBackground"] =
				_colorBrushesBackground[new Random().Next(0, _colorBrushesBackground.Count - 1)];
		}
		private void ChangeForeground_OnClick(object sender, RoutedEventArgs e)
		{
			Resources[@"ColorBrushForeground"] =
				_colorBrushesForeground[new Random().Next(0, _colorBrushesForeground.Count - 1)];
		}

		private void ButtonScroll_OnClick(object sender, RoutedEventArgs e)
		{
			Resources[@"ColorBrushScroll"] =
				_colorBrushesScroll[new Random().Next(0, _colorBrushesScroll.Count - 1)];
		}

		private void ChangeImage_OnClick(object sender, RoutedEventArgs e)
		{
			var openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() != true) return;
			var filePath = openFileDialog.FileName;
			var bitmapImage = new BitmapImage(new Uri(filePath));
			Resources[@"ButtonBitmapImage"] = bitmapImage;
		}
	}
}