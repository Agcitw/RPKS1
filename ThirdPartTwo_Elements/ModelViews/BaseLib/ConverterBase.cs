using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ThirdPartTwo_Elements.ModelViews.BaseLib
{
	public abstract class ConverterBase : MarkupExtension, IValueConverter
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			throw new NotImplementedException();
		}

		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}