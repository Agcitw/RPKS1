using System.Collections.Generic;
using System.Linq;

namespace Second
{
	public class ObservationRoom
	{
		public int Capacity { get; }
		public readonly Queue<Human> Queue = new Queue<Human>();

		public ObservationRoom(int capacity) =>
			Capacity = capacity;

		public bool IsQueueHasInfected() => 
			Queue.Aggregate(false, (current, human) => current | human.IsInfected);
		
	}
}