using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
	public delegate bool Rule(object data);
	public class Validator<T>
	{
		private readonly List<Rule> _collectionOfRules = new List<Rule>();
		public Validator<T> Successor { get; set; }
		public void Handle(T data)
		{
			if (_collectionOfRules.Count == 0)
				throw new NoRulesException();
			if (_collectionOfRules.Select(rule => rule.Invoke(data)).Any(resultOfCheck => !resultOfCheck))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
		public void AddRule(Rule rule) =>
			_collectionOfRules.Add(rule);
	}
}