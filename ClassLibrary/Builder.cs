namespace ClassLibrary
{
	public abstract class Builder<T>
	{
		protected readonly ConcreteValidator<T> ConcreteConcreteValidator = new ConcreteValidator<T>();
		public abstract void Build();
		public Validator<T> GetResult() => ConcreteConcreteValidator;
	}
}