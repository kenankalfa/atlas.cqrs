namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemDescriptionChangedEventHandler : IEventHandler<DiaryItemDescriptionChangedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemDescriptionChangedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }

        public void Handle(DiaryItemDescriptionChangedEvent @event)
        {
            var readModel = _repository.Get(@event.AggregateId);
            readModel.Description = @event.Description;
            readModel.Version = @event.Version;
            _repository.Update(readModel);
        }
    }
}
