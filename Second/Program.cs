namespace Second
{
	internal static class Program
	{
		private const int M = 15;
		private const int N = 5;
		private const int T = 2_000;

		public static void Main()
		{
			var infectDep = new InfectDiseasesDepartment(M, N, T);
			infectDep.StartWork();
		}
	}
}