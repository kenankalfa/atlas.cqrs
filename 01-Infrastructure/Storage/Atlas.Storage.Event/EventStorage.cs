using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Storage
{
    using Atlas.Core;
    using Atlas.Core.Exception;
    public class EventStorage : IEventStorage
    {
        private IEventRepository _eventRepository;
        private IEventStoragePolicy _eventStoragePolicy;
        private IEventBus _eventBus;
        public EventStorage(IEventRepository eventRepository, IEventStoragePolicy eventStoragePolicy, IEventBus eventBus)
        {
            _eventRepository = eventRepository;
            _eventStoragePolicy = eventStoragePolicy;
            _eventBus = eventBus;
        }

        public IEnumerable<IEvent> GetEvents(Guid aggregateId)
        {
            var events = _eventRepository.GetEvents(aggregateId);

            if (!(events != null && events.Any()))
            {
                throw new AggregateNotFoundException(string.Format("AggregateId : {0} not found.", aggregateId));
            }

            return events;
        }

        public void Save(AggregateRoot aggregate)
        {
            if (!_eventStoragePolicy.StoragePolicy(aggregate))
            {
                throw new ConcurrencyException(string.Format("AggregateId : {0} has already updated.", aggregate.AggregateId));
            }

            var uncommitedEvents = aggregate.GetUncommitedChanges();

            if (!(uncommitedEvents != null && uncommitedEvents.Any()))
            {
                throw new AggregateNotFoundException(string.Format("AggregateId : {0} not found.", aggregate.AggregateId));
            }

            var currentVersionCounter = aggregate.Version;

            foreach (var @event in uncommitedEvents)
            {
                currentVersionCounter++;
                @event.Version = currentVersionCounter;
            }

            _eventRepository.SaveEvents(aggregate.AggregateId, uncommitedEvents);

            foreach (var @event in uncommitedEvents)
            {
                _eventBus.Publish(@event);
            }
        }
    }
}
