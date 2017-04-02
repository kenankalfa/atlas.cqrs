using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemDeletedEvent : Event
    {
        public DiaryItemDeletedEvent(Guid aggregateId) : base(aggregateId)
        {

        }
    }
}
