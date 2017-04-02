using System;
using System.Collections.Generic;

namespace Atlas.Storage
{
    using Atlas.Core;
    public interface IEventStorage
    {
        IEnumerable<IEvent> GetEvents(Guid aggregateId);
        void Save(AggregateRoot aggregate);
    }
}
