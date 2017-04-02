namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemToChangedEventHandler : IEventHandler<DiaryItemToChangedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemToChangedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }

        public void Handle(DiaryItemToChangedEvent @event)
        {
            var readModel = _repository.Get(@event.AggregateId);
            readModel.To = @event.To;
            readModel.Version = @event.Version;
            _repository.Update(readModel);
        }
    }
}
