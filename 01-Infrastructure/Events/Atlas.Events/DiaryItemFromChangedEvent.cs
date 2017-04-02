using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemFromChangedEvent : Event
    {
        public DateTime From { get; private set; }

        public DiaryItemFromChangedEvent(Guid aggregateId,DateTime from):base(aggregateId)
        {
            From = from;
        }
    }
}
