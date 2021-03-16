using System;

namespace ClassLibrary
{
	public class NoRulesException : AggregateException
	{
		public override string Message { get; }
		public NoRulesException()
		{
			Message = "No rules in your validator";
		}
	}

	public class BadCheckException : AggregateException
	{
		public override string Message { get; }
		public BadCheckException()
		{
			Message = "Check not completed";
		}
	}
}