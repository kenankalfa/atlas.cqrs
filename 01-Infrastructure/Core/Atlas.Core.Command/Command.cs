using System;

namespace Atlas.Core
{
    [Serializable]
    public class Command : ICommand
    {
        public Guid AggregateId { get; private set; }
        public int Version { get; private set; }

        public Command(Guid aggregateId, int version)
        {
            AggregateId = aggregateId;
            Version = version;
        }
    }
}
