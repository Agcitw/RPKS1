using System;
using System.Globalization;
using System.Windows;

namespace ThirdPartTwo_Elements.ModelViews.BaseLib
{
	public class BoolToVisibility : ConverterBase
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(value is bool b) ? throw new ArgumentException(string.Empty, nameof(value)) :
				b ? Visibility.Visible : Visibility.Collapsed;
		}
	}

	public class NullToBool : ConverterBase
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(value is null);
		}
	}

	public class NullToVisibility : ConverterBase
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value is null ? Visibility.Collapsed : Visibility.Visible;
		}
	}

	public class Percentage : ConverterBase
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is double d)) throw new ArgumentException(nameof(value));
			if (!(parameter is double p)) throw new ArgumentException(nameof(parameter));
			return d * p;
		}
	}

	public class MultiBoolToBool : MultiConverterBase
	{
		public enum Cases
		{
			TrueAll,
			TrueOne,
			FalseAll,
			FalseOne
		}

		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(parameter is Cases p))
				throw new ArgumentException(nameof(parameter));
			foreach (var value in values)
			{
				if (!(value is bool b))
					throw new ArgumentException(nameof(value));
				switch (p)
				{
					case Cases.TrueAll when !b: return false;
					case Cases.TrueAll: break;
					case Cases.TrueOne when b: return true;
					case Cases.TrueOne: break;
					case Cases.FalseAll when b: return false;
					case Cases.FalseAll: break;
					case Cases.FalseOne when !b: return true;
					case Cases.FalseOne: break;
					default: throw new ArgumentOutOfRangeException();
				}
			}

			switch (p)
			{
				case Cases.TrueAll: return true;
				case Cases.FalseAll: return true;
				case Cases.TrueOne: return false;
				case Cases.FalseOne: return false;
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}

	public class MultiBoolToVisibility : MultiConverterBase
	{
		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(parameter is Cases p))
				throw new ArgumentException(nameof(parameter));
			foreach (var item in values)
			{
				if (!(item is bool b))
					throw new ArgumentException(nameof(item));
				switch (p)
				{
					case Cases.TrueAll when !b: return Visibility.Collapsed;
					case Cases.TrueAll: break;
					case Cases.TrueOne when b: return Visibility.Visible;
					case Cases.TrueOne: break;
					case Cases.FalseAll when b: return Visibility.Collapsed;
					case Cases.FalseAll: break;
					case Cases.FalseOne when !b: return Visibility.Visible;
					case Cases.FalseOne: break;
					default: throw new ArgumentOutOfRangeException();
				}
			}

			switch (p)
			{
				case Cases.TrueAll: return Visibility.Visible;
				case Cases.FalseAll: return Visibility.Visible;
				case Cases.TrueOne: return Visibility.Collapsed;
				case Cases.FalseOne: return Visibility.Collapsed;
				default: throw new ArgumentOutOfRangeException();
			}
		}

		private enum Cases
		{
			TrueAll,
			TrueOne,
			FalseAll,
			FalseOne
		}
	}
}