using ClassLibrary;

namespace First
{
	public static class Client
	{
		public static void Main()
		{
			Builder<string> builderStr = new ValidatorBuilderStr1<string>();
			builderStr.Build();
			var validatorStr = builderStr.GetResult();
			
			Builder<string> builderStr2 = new ValidatorBuilderStr2<string>();
			builderStr2.Build();
			var validatorStr2 = builderStr2.GetResult();

			validatorStr.Successor = validatorStr2;
			validatorStr.Request("hello");
			
			Builder<int> builderInt = new ValidatorBuilderInt1<int>();
			builderInt.Build();
			var validatorInt = builderInt.GetResult();
			
			Builder<int> builderInt2 = new ValidatorBuilderInt2<int>();
			builderInt2.Build();
			var validatorInt2 = builderInt2.GetResult();

			validatorInt.Successor = validatorInt2;
			validatorInt.Request(0);
		}
	}
}