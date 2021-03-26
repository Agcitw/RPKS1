using System;

namespace Second
{
	public class Human
	{
		private const double ProbabilityForInf = 0.2;
		private const double ProbabilityForSpec = 0.05;
		public bool IsInfected { get; set; }
		public bool IsSpecial { get; set; }

		public Human()
		{
			var n1 = new Random().Next(0, 100);
			var n2 = new Random().Next(0, 100);
			const double p1 = ProbabilityForInf * 100;
			const double p2 = ProbabilityForSpec * 100;
			IsInfected = n1 <= p1;
			IsSpecial = n2 <= p2;
		}
	}
}