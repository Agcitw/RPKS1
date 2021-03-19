using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NLog;

namespace Second
{
	public class InfectDiseasesDepartment
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();
		
		private ObservationRoom _observationRoom;               //M
		private List<Doctor> _doctors;                          //N
		public static int LimitOfWaiting { get; private set;  } //T
		private static readonly TimerCallback TimerCallback = InfectAll;
		private static Timer _timerForQueue;
		private static int PeriodToInfectAll = 60_000;
		public static Queue<Human> _queueToObservationRoom = new Queue<Human>();

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

		private static void InfectAll(object o)
		{
			foreach (var human in _queueToObservationRoom)
			{
				human.IsInfected = true;
			}
		}
		
		public void Startwork()
		{
			//_timerForQueue = new Timer(TimerCallback, null, 0, PeriodToInfectAll);
			//TODO: смоделировать работу, случайное кол-во людей
		}
	}

	public class ObservationRoom
	{
		public int Capacity { get; }
		public Queue<Human> Queue;

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