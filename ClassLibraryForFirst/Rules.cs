using System.Linq;

namespace ClassLibrary
{
	public static class Rules
	{
		public static bool IsNotNull(object data)
		{
			return data != null;
		}

		public static bool IsPositiveNumber(object data)
		{
			return data as int? >= 0;
		}

		public static bool IsStringWithoutUpperChars(object data)
		{
			return (data as string ?? string.Empty).Count(char.IsUpper) == 0;
		}

		public static bool IsZero(object data)
		{
			return data as int? == 0;
		}
	}
}