using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Storage
{
    using Atlas.Core;
    public interface IEventStoragePolicy
    {
        bool StoragePolicy(AggregateRoot aggregateRoot);
    }
}
