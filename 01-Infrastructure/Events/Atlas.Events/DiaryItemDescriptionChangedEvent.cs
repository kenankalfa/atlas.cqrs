using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemDescriptionChangedEvent : Event
    {
        public string Description { get; private set; }

        public DiaryItemDescriptionChangedEvent(Guid aggregateId,string description): base(aggregateId)
        {
            Description = description;
        }
    }
}
