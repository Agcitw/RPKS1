namespace ClassLibrary
{
	public abstract class Builder<T>
	{
		protected Validator<T> Validator { get; } = new Validator<T>();
		public Validator<T> GetResult() => 
			Validator;
		public abstract void Build();
	}

	public class ConcreteBuilder<T> : Builder<T>
	{
		public override void Build()
		{
			if (typeof(T) == typeof(int))
			{
				Validator.AddCheckOnZero();
				Validator.AddCheckOnPositiveNumber();
			}
			if (typeof(T) == typeof(string))
			{
				Validator.AddCheckOnNotNull();
				Validator.AddCheckOnStringWithoutUpperChars();
			}
			Validator.FormTheChain();
		}
	}
}