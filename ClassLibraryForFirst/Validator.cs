using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
	public delegate bool Rule(object data);
	public class Validator<T>
	{
		private readonly Lazy<List<Rule>> _collectionOfRules = new Lazy<List<Rule>>();
		public Validator<T> Successor { get; set; }
		public void Handle(T data)
		{
			if (_collectionOfRules.Value.Count == 0)
				throw new NoRulesException();
			if (_collectionOfRules.Value.Select(rule => rule.Invoke(data)).Any(resultOfCheck => !resultOfCheck))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
		public void AddRule(Rule rule) =>
			_collectionOfRules.Value.Add(rule);
	}
}