using System;

namespace Atlas.Core
{
    public interface ICommand
    {
        Guid AggregateId { get; }
        int Version { get; }
    }
}
