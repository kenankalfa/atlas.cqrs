using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemToChangedEvent : Event
    {
        public DateTime To { get; private set; }

        public DiaryItemToChangedEvent(Guid aggregateId,DateTime to):base(aggregateId)
        {
            To = to;
        }
    }
}
