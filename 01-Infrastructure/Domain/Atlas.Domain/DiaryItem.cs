using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Domain
{
    using Atlas.Core;
    using Atlas.Events;
    public class DiaryItem : AggregateRoot,
                             IHandle<DiaryItemCreatedEvent>,
                             IHandle<DiaryItemDeletedEvent>,
                             IHandle<DiaryItemDescriptionChangedEvent>,
                             IHandle<DiaryItemFromChangedEvent>,
                             IHandle<DiaryItemTitleChangedEvent>,
                             IHandle<DiaryItemToChangedEvent>
    {
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }
        public DiaryState State { get; set; }

        public DiaryItem()
        {

        }

        public DiaryItem(Guid id, string title, string description, DateTime from, DateTime to)
        {
            Apply(new DiaryItemCreatedEvent(id, title, from, to, description));
        }

        public void Delete()
        {
            Apply(new DiaryItemDeletedEvent(AggregateId));
        }

        public void ChangeDescription(string description)
        {
            Apply(new DiaryItemDescriptionChangedEvent(AggregateId, description));
        }

        public void ChangeFrom(DateTime from)
        {
            Apply(new DiaryItemFromChangedEvent(AggregateId, from));
        }

        public void ChangeTo(DateTime to)
        {
            Apply(new DiaryItemToChangedEvent(AggregateId, to));
        }

        public void ChangeTitle(string title)
        {
            Apply(new DiaryItemTitleChangedEvent(AggregateId, title));
        }

        public void Handle(DiaryItemCreatedEvent @event)
        {
            Title = @event.Title;
            From = @event.From;
            To = @event.To;
            Description = @event.Description;
            Version = @event.Version;
            AggregateId = @event.AggregateId;
        }

        public void Handle(DiaryItemDeletedEvent @event)
        {
            State = DiaryState.Passive;
        }

        public void Handle(DiaryItemDescriptionChangedEvent @event)
        {
            Description = @event.Description;
        }

        public void Handle(DiaryItemFromChangedEvent @event)
        {
            From = @event.From;
        }

        public void Handle(DiaryItemTitleChangedEvent @event)
        {
            Title = @event.Title;
        }

        public void Handle(DiaryItemToChangedEvent @event)
        {
            To = @event.To;
        }
    }
}
