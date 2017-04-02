using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemTitleChangedEvent : Event
    {
        public string Title { get; private set; }

        public DiaryItemTitleChangedEvent(Guid aggregateId,string title):base(aggregateId)
        {
            Title = title;
        }
    }
}
