using System;
using System.Threading.Tasks;

namespace Second
{
	public class Doctor
	{
		public bool IsBusy = false;

		public async void WorkWithPatient(Human human)
		{
			IsBusy = true;

			if (human.IsSpecial)
			{
				//TODO: позвать др доктора
			}

			await Task.Delay(new Random().Next(1, InfectDiseasesDepartment.LimitOfWaiting));
			
			//удалить из очереди
			//log
			
			IsBusy = false;
		}
	}
}