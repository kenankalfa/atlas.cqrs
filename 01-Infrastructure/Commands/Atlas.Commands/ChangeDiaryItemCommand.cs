using System;

namespace Atlas.Commands
{
    using Atlas.Core;
    public class ChangeDiaryItemCommand : Command
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public ChangeDiaryItemCommand(Guid AggregateId,string title,string description,DateTime from,DateTime to,int version)
            :base(AggregateId, version)
        {
            Title = title;
            Description = description;
            From = from;
            To = to;
        }
    }
}
