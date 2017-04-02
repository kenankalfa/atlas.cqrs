using System;

namespace Atlas.Events
{
    using Atlas.Core;
    public class DiaryItemCreatedEvent : Event
    {
        public string Title { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public string Description { get; private set; }

        public DiaryItemCreatedEvent(Guid aggregateId,string title,DateTime from,DateTime to,string description):base(aggregateId)
        {
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}
