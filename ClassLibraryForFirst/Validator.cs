using System.Collections.Generic;

namespace ClassLibrary
{
	public class Validator<T>
	{
		private readonly List<ElementOfChain> _collectionOfRules = new List<ElementOfChain>();
		public void FormTheChain()
		{
			for (var i = 1; i < _collectionOfRules.Count; i++)
				_collectionOfRules[i - 1].Successor = _collectionOfRules[i];
		}
		public void Check(T data)
		{
			if (_collectionOfRules.Count == 0)
				throw new NoRulesException();
			_collectionOfRules[0].Handle(data);
		}
		#region Add's
		public void AddCheckOnNotNull() =>
			_collectionOfRules.Add(new CheckOnNotNull());
		public void AddCheckOnPositiveNumber() =>
			_collectionOfRules.Add(new CheckOnPositiveNumber());
		public void AddCheckOnZero() => 
			_collectionOfRules.Add(new CheckOnZero());
		public void AddCheckOnStringWithoutUpperChars() =>
			_collectionOfRules.Add(new CheckOnStringWithoutUpperChars());
		#endregion
	}
}