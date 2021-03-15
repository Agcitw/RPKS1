using System.Linq;

namespace ClassLibrary
{
	public static class Rules
	{
		public static bool IsNotNull(object data) =>
			data != null;

		public static bool IsPositiveNumber(object data) =>
			data as int? >= 0;

		public static bool IsStringWithoutUpperChars(object data) =>
			(data as string ?? string.Empty).Count(char.IsUpper) == 0;
		
		public static bool IsZero(object data) =>
			data as int? == 0;
	}
}