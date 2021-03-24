using System.Collections.Generic;
using System.Linq;
using System.Timers;
using NLog;

namespace Second
{
	public class InfectDiseasesDepartment
	{
		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		private static Timer _timerForQueueInfect;
		private readonly ObservationRoom _observationRoom;
		private List<Doctor> _doctors;
		public static int LimitOfWaiting { get; private set; }
		private const int PeriodToInfectAll = 60_000; //ms
		private static readonly Queue<Human> QueueToObservationRoom = new Queue<Human>();
		
		public InfectDiseasesDepartment(int n, int m, int t)
		{
			_observationRoom = new ObservationRoom(n);
			_doctors = new List<Doctor>(m);
			LimitOfWaiting = t;
		}
		
		public void StartWork()
		{
			SetTimer();

			
			




			StopTimer();
		}
		
		private void NewPatientToQueue(Human human)
		{
			if (_observationRoom.Queue.Count < _observationRoom.Capacity &&
			    _observationRoom.IsQueueHasInfected() == human.IsInfected)
				_observationRoom.Queue.Enqueue(human);
			else
				QueueToObservationRoom.Enqueue(human);
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
            Logger.Info("All in queue are infected");
        }
		#endregion
	}
}