using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Storage
{
    using Atlas.Core;
    using Atlas.Core.Exception;

    public class AggregateRootRepository<T> : IAggregateRootRepository<T> where T : AggregateRoot, new()
    {
        private IEventStorage _eventStorage;
        private static object _lockStorage = new object();

        public AggregateRootRepository(IEventStorage eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public T GetById(Guid id)
        {
            var aggregateRoot = new T();
            var events = _eventStorage.GetEvents(id);
            aggregateRoot.LoadsFromHistory(events);
            return aggregateRoot;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            lock (_lockStorage)
            {
                var item = GetById(aggregate.AggregateId);

                if (item.Version != expectedVersion)
                {
                    throw new ConcurrencyException(string.Format("Aggregate {0} has been previously modified", item.AggregateId));
                }

                _eventStorage.Save(aggregate);
            }
        }
    }
}
