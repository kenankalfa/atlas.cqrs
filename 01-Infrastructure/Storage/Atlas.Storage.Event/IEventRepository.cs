using System;
using System.Collections.Generic;

namespace Atlas.Storage
{
    using Atlas.Core;
    public interface IEventRepository
    {
        List<Event> GetEvents(Guid AggregateId);
        bool SaveEvents(Guid AggregateId, IEnumerable<IEvent> events);
    }
}
