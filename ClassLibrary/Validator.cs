using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
	public delegate bool Rule(object data);
	public abstract class Validator<T>
	{
		protected readonly List<Rule> CollectionOfRules = new List<Rule>();
		public Validator<T> Successor { get; set; }
		public abstract void Request(T data);
		public void AddRule(Rule rule)
		{
			CollectionOfRules.Add(rule);
		}
	}

	public class ConcreteValidator<T> : Validator<T>
	{
		public override void Request(T data)
		{
			if (CollectionOfRules.Count == 0)
				throw new AggregateException("No rules");
			
			if (CollectionOfRules.Select(rule => rule.Invoke(data)).Any(resultOfCheck => !resultOfCheck))
			{
				throw new AggregateException("Check is not completed");
			}

			Successor?.Request(data);
		}
	}
}