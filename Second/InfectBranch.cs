using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using NLog;
using Timer = System.Timers.Timer;

namespace Second
{
	public class InfectDiseasesDepartment
	{
		private const int PeriodToInfectAll = 10_000;
		private const int PeriodToSpawnHuman = 1_000;
		public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		private static Timer _timerForQueueInfect;
		private readonly int _countOfHumans = new Random().Next(100, 1000);
		private readonly List<Doctor> _doctors;
		private readonly ObservationRoom _observationRoom;
		public readonly Queue<Human> QueueToObservationRoom = new Queue<Human>();

		public InfectDiseasesDepartment(int n, int m, int t)
		{
			_observationRoom = new ObservationRoom(n);
			_doctors = new List<Doctor>();
			for (var i = 0; i < m; i++)
				_doctors.Add(new Doctor());
			LimitOfWaiting = t;
			Logger.Info("Created infect deseases departament");
		}

		public static int LimitOfWaiting { get; private set; }

		public void StartWork()
		{
			Logger.Info("Work with patients was started");
			SetInfectTimer();
			GenerateNewHumans();
			Thread.Sleep(5_000);
			_observationRoom.StartHelpPatients(_doctors, this);
			StopInfectTimer();
		}

		public Doctor GetFreeDoctor()
		{
			Doctor freeDoctor;
			while (true)
			{
				freeDoctor = _doctors.FirstOrDefault(doctor => !doctor.IsBusy);
				if (freeDoctor != null) break;
			}

			return freeDoctor;
		}

		#region SpawnerOfHumans

		private void NewPatientToQueue(Human human)
		{
			if (_observationRoom.Queue.Count < _observationRoom.Capacity &&
			    _observationRoom.IsQueueHasInfected() == human.IsInfected ||
			    _observationRoom.Queue.Count == 0)
			{
				_observationRoom.Queue.Enqueue(human);
				Logger.Info(
					$"New patient in observation room: isInfected={human.IsInfected}, isSpecial={human.IsSpecial}");
			}
			else
			{
				QueueToObservationRoom.Enqueue(human);
				Logger.Info(
					$"New patient in queue to observation room: isInfected={human.IsInfected}, isSpecial={human.IsSpecial}");
			}
		}

		private async void GenerateNewHumans()
		{
			await Task.Run(() =>
			{
				for (var i = 0; i < _countOfHumans; i++)
				{
					Thread.Sleep(new Random().Next(PeriodToSpawnHuman));
					NewPatientToQueue(new Human());
				}
			});
		}

		#endregion

		#region InfectTimer

		private void SetInfectTimer()
		{
			_timerForQueueInfect = new Timer(PeriodToInfectAll);
			_timerForQueueInfect.Elapsed += OnTimedEventInfect;
			_timerForQueueInfect.AutoReset = true;
			_timerForQueueInfect.Enabled = true;
		}

		private static void StopInfectTimer()
		{
			_timerForQueueInfect.Stop();
			_timerForQueueInfect.Dispose();
		}

		private void OnTimedEventInfect(object source, ElapsedEventArgs e)
		{
			var infectFlag = false;
			foreach (var unused in QueueToObservationRoom.Where(h => h.IsInfected))
				infectFlag = true;
			if (infectFlag)
				InfectAll();
		}

		private void InfectAll()
		{
			foreach (var human in QueueToObservationRoom)
				human.IsInfected = true;
			if (QueueToObservationRoom.Count != 0)
				Logger.Info($"{QueueToObservationRoom.Count} humans are infected");
		}

		#endregion
	}
}