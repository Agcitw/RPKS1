using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Third
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private int _imageInd = 1;
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
			var b1 = new BitmapImage(new Uri("Images/botimage (2).jpeg", UriKind.Relative));
			var b2 = new BitmapImage(new Uri("Images/Apex-Legends-HD-Wallpapers-and-Background-Images-Wallpaper-Cart.png", UriKind.Relative));
			var img = new Image {Source = _imageInd == 0 ? b1 : b2};
			_imageInd = _imageInd == 0 ? 1 : 0;
			Resources[@"MyImage"] = img;
		}
	}
}