using System;
using ClassLibrary;

namespace First
{
	public static class Client
	{
		public static void Main()
		{
			try
			{
				Builder<string> builder1 = new ConcreteBuilder<string>();
				builder1.Build();
				var validator1 = builder1.GetResult();
				validator1.Check("string for test");
				//more checks...

				Builder<int> builder2 = new ConcreteBuilder<int>();
				builder2.Build();
				var validator2 = builder2.GetResult();
				validator2.Check(0);
				//more checks...
			}
			catch (NoRulesException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (BadCheckException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}