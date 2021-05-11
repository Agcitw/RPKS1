using System.Collections.Generic;
using System.Linq;

namespace Second
{
	public class ObservationRoom
	{
		public readonly Queue<Human> Queue = new Queue<Human>();

		public ObservationRoom(int capacity)
		{
			Capacity = capacity;
		}

		public int Capacity { get; }

		public bool IsQueueHasInfected()
		{
			return Queue.Any(human => human.IsInfected);
		}

		public void StartHelpPatients(List<Doctor> doctors, InfectDiseasesDepartment branch)
		{
			while (branch.QueueToObservationRoom.Count != 0 || Queue.Count != 0)
			{
				var doctor = doctors.FirstOrDefault(d => !d.IsBusy);
				if (doctor == null) continue;
				doctor.WorkWithPatient(Queue.Dequeue(), branch);
				if (branch.QueueToObservationRoom.Count != 0)
					Queue.Enqueue(branch.QueueToObservationRoom.Dequeue());
			}
		}
	}
}