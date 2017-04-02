using System;
using System.Collections.Generic;
using System.Linq;

namespace Atlas.Core
{
    public abstract class AggregateRoot : IAggregateRoot, IEventProvider
    {
        private IList<IEvent> _events = default(IList<IEvent>);

        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public int EventVersion { get; set; }

        public AggregateRoot()
        {
            _events = _events ?? new List<IEvent>(); 
        }

        public virtual IEnumerable<IEvent> GetUncommitedChanges()
        {
            return _events;
        }

        public virtual void LoadsFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
            Version = history.Last().Version;
            EventVersion = Version;
        }

        protected void Apply(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IEvent @event, bool isNew)
        {
            dynamic aggregateRootHandableEventObject = this;

            aggregateRootHandableEventObject.Handle(Converter.ChangeTo(@event, @event.GetType()));

            if (isNew)
            {
                _events.Add(@event);
            }
        }
    }
}
