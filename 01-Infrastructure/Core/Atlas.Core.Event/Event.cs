using System;

namespace Atlas.Core
{
    [Serializable]
    public class Event : IEvent
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }

        public Event()
        {

        }

        public Event(Guid aggregateId, int version = -1)
        {
            AggregateId = aggregateId;
            Version = Version;
        }
    }
}
