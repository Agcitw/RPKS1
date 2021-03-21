namespace Second
{
	internal static class Program
	{
		private const int M = 1;
		private const int N = 1;
		private const int T = 1;
		public static void Main()
		{
			var infectDep = new InfectDiseasesDepartment(M, N, T);
			infectDep.Startwork();
			

		}
	}
}