namespace ClassLibrary
{
	public abstract class ElementOfChain //<T>
	{
		public ElementOfChain Successor { get; set; }
		public abstract void Handle(object data);
	}

	public class CheckOnNotNull : ElementOfChain
	{
		public override void Handle(object data)
		{
			if (!Rules.IsNotNull(data))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
	}
	
	public class CheckOnPositiveNumber : ElementOfChain
	{
		public override void Handle(object data)
		{
			if (!Rules.IsPositiveNumber(data))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
	}
	
	public class CheckOnZero : ElementOfChain
	{
		public override void Handle(object data)
		{
			if (!Rules.IsZero(data))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
	}
	
	public class CheckOnStringWithoutUpperChars : ElementOfChain
	{
		public override void Handle(object data)
		{
			if (!Rules.IsStringWithoutUpperChars(data))
				throw new BadCheckException();
			Successor?.Handle(data);
		}
	}
}