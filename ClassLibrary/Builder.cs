namespace ClassLibrary
{
	public abstract class Builder<T>
	{
		protected readonly Validator<T> Validator = new Validator<T>();
		public Validator<T> GetResult() => Validator;
		public abstract void Build();
	}
}