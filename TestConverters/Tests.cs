using System;
using System.Globalization;
using System.Windows;
using NUnit.Framework;
using ThirdPartTwo_Elements.ModelViews.BaseLib;

namespace TestConverters
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void Test1()
		{
			var bv = new BoolToVisibility();
			var res = bv.Convert(true, typeof(bool), new object(), new CultureInfo(0));
			Assert.AreEqual((Visibility)res, Visibility.Collapsed);
		}
	}
}