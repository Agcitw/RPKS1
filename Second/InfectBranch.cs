using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using NLog;

namespace Second
{
	public class InfectDiseasesDepartment
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();
		private static Timer _timerForQueueInfect;
		private readonly ObservationRoom _observationRoom;
		private List<Doctor> _doctors;
		public static int LimitOfWaiting { get; private set;  }
		private const int PeriodToInfectAll = 60_000;
		private static readonly Queue<Human> QueueToObservationRoom = new Queue<Human>();
		

		public InfectDiseasesDepartment(int n, int m, int t)
		{
			_observationRoom = new ObservationRoom(n);
			_doctors = new List<Doctor>(m);
			LimitOfWaiting = t;
		}

		private void NewPatientToQueue(Human human)
		{
			if (_observationRoom.Queue.Count < _observationRoom.Capacity &&
			    _observationRoom.IsQueueInfected() == human.IsInfected)
				_observationRoom.Queue.Enqueue(human);
			else
				QueueToObservationRoom.Enqueue(human);
		}
		
		public void Startwork()
		{
			SetTimer();

			
			//for...
			var patients = new List<Human>();
			for (var i = 0; i < 30; i++)
				patients.Add(new Human(false, false));
			foreach (var patient in patients)
				NewPatientToQueue(patient);
			
				
				

			StopTimer();
		}

		#region InfectTimer
		private static void SetTimer()
        {
        	_timerForQueueInfect = new Timer(PeriodToInfectAll);
        	_timerForQueueInfect.Elapsed += OnTimedEvent;
        	_timerForQueueInfect.AutoReset = true;
        	_timerForQueueInfect.Enabled = true;
        }
		private static void StopTimer()
        {
        	_timerForQueueInfect.Stop();
        	_timerForQueueInfect.Dispose();
        }
		private static void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			var infectFlag = false;
			foreach (var h in QueueToObservationRoom.Where(h => h.IsInfected))
				infectFlag = true;
			if (infectFlag)
				InfectAll();
		}
		private static void InfectAll()
        {
        	foreach (var human in QueueToObservationRoom)
        		human.IsInfected = true;
        }
		#endregion
	}

	public class ObservationRoom
	{
		public int Capacity { get; }
		public readonly Queue<Human> Queue = new Queue<Human>();

		public ObservationRoom(int capacity) =>
			Capacity = capacity;

		public bool IsQueueInfected() => 
			Queue.Aggregate(false, (current, human) => current | human.IsInfected);
	}

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
			
			IsBusy = false;
		}
	}

	public class Human
	{
		public bool IsInfected { get; set; }
		public bool IsSpecial { get; }

		public Human(bool isInfected, bool isSpecial)
		{
			IsInfected = isInfected;
			IsSpecial = isSpecial;
		}
	}
}