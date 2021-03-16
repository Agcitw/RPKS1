namespace ClassLibrary
{
	public abstract class Builder<T>
	{
		protected readonly Validator<T> Validator = new Validator<T>();
		public abstract void Build();
		public Validator<T> GetResult() => Validator;
	}
}