using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThirdPartTwo_Elements.Views
{
	public partial class MessageDialog : UserControl
	{
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

		public MessageDialog()
		{
			InitializeComponent();
		}
		
		public void ButtonScroll_OnClick(object sender, RoutedEventArgs e)
		{
			Resources[@"ColorBrushScroll"] =
				_colorBrushesScroll[new Random().Next(0, _colorBrushesScroll.Count - 1)];
		}
	}
}