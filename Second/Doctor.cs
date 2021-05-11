using System;
using System.Threading.Tasks;

namespace Second
{
	public class Doctor
	{
		public bool IsBusy;

		public async void WorkWithPatient(Human human, InfectDiseasesDepartment branch)
		{
			IsBusy = true;
			Doctor doctorForHelp = null;
			if (human.IsSpecial)
			{
				human.IsSpecial = false;
				doctorForHelp = branch.GetFreeDoctor();
				doctorForHelp.IsBusy = true;
				InfectDiseasesDepartment.Logger.Info("Called second doctor for help");
			}

			var time = new Random().Next(1000, InfectDiseasesDepartment.LimitOfWaiting);
			await Task.Delay(time);
			human.IsInfected = false;
			InfectDiseasesDepartment.Logger.Info($"Human is healthy, awaiting time={time}");
			if (doctorForHelp != null) doctorForHelp.IsBusy = false;
			IsBusy = false;
		}
	}
}