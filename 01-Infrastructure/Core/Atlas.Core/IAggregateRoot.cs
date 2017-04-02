using System;

namespace Atlas.Core
{
    public interface IAggregateRoot
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
    }
}
