using System;

namespace Atlas.Core
{
    public interface IEvent
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
    }
}
