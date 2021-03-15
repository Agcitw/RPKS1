using System;

namespace ClassLibrary
{
	public class AggregateException : Exception
	{
		public AggregateException(string message) : base(message)
		{
		}

		public void PrintMessage()
		{
			Console.WriteLine(Message);
		}
	}
}