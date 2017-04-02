namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemFromChangedEventHandler : IEventHandler<DiaryItemFromChangedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemFromChangedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }

        public void Handle(DiaryItemFromChangedEvent @event)
        {
            var readModel = _repository.Get(@event.AggregateId);
            readModel.From = @event.From;
            readModel.Version = @event.Version;
            _repository.Update(readModel);
        }
    }
}
