using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using NLog;

namespace Second
{
	public class InfectDiseasesDepartment
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();
		private readonly ObservationRoom _observationRoom;
		private List<Doctor> _doctors;
		public static int LimitOfWaiting { get; private set;  }
		private static int PeriodToInfectAll = 60_000;
		public static Queue<Human> _queueToObservationRoom = new Queue<Human>();
		private static System.Timers.Timer timerForQueueInfect;
		
		public InfectDiseasesDepartment(int n, int m, int t)
		{
			_observationRoom = new ObservationRoom(n);
			_doctors = new List<Doctor>(m);
			LimitOfWaiting = t;
		}

		public void NewPatient(Human human)
		{
			if (_observationRoom.Queue.Count < _observationRoom.Capacity &&
			    _observationRoom.IsQueueInfected() == human.IsInfected)
				_observationRoom.Queue.Enqueue(human);
			else
				_queueToObservationRoom.Enqueue(human);
		}
		
		public void Startwork()
		{
			timerForQueueInfect = new System.Timers.Timer(PeriodToInfectAll);
			timerForQueueInfect.Elapsed += OnTimedEvent;
			timerForQueueInfect.AutoReset = true;
			timerForQueueInfect.Enabled = true;
			
			//TODO: смоделировать работу, случайное кол-во людей
			
			
			timerForQueueInfect.Stop();
			timerForQueueInfect.Dispose();
		}
		
		private static void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			var infectFlag = false;
			foreach (var h in _queueToObservationRoom.Where(h => h.IsInfected))
				infectFlag = true;
			if (infectFlag)
				InfectAll();
		}
		private static void InfectAll()
        {
        	foreach (var human in _queueToObservationRoom)
        		human.IsInfected = true;
        }
	}

	public class ObservationRoom
	{
		public int Capacity { get; }
		public Queue<Human> Queue = new Queue<Human>();

		public ObservationRoom(int capacity)
		{
			Capacity = capacity;
		}

		public bool IsQueueInfected() => 
			Queue.Aggregate(false, (current, human) => current | human.IsInfected);
	}

	public class Doctor
	{
		public bool IsBusy = false;

		public void WorkWithPatient(Human human)
		{
			IsBusy = true;

			if (human.IsSpecial)
			{
				//TODO: позвать др доктора
			}

			Thread.Sleep(new Random().Next(1, InfectDiseasesDepartment.LimitOfWaiting));
			
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