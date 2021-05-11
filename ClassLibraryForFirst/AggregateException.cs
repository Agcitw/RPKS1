using System;

namespace ClassLibrary
{
	public class NoRulesException : AggregateException
	{
		public NoRulesException()
		{
			Message = "No rules in your validator";
		}

		public override string Message { get; }
	}

	public class BadCheckException : AggregateException
	{
		public BadCheckException()
		{
			Message = "Check is not completed";
		}

		public override string Message { get; }
	}
}