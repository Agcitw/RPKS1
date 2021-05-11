using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThirdPartTwo_Elements.Views
{
	public partial class MessageDialog : UserControl
	{
		private readonly List<SolidColorBrush> _colorBrushesScroll = new()
		{
			new(Colors.Green),
			new(Colors.Red),
			new(Colors.Yellow),
			new(Colors.Orange),
			new(Colors.Pink),
			new(Colors.RosyBrown),
			new(Colors.Gold),
			new(Colors.Orchid),
			new(Colors.Lime),
			new(Colors.GreenYellow),
			new(Colors.CornflowerBlue)
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