namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemDeletedEventHandler : IEventHandler<DiaryItemDeletedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemDeletedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }
        public void Handle(DiaryItemDeletedEvent @event)
        {
            var readModel = _repository.Get(@event.AggregateId);
            _repository.Delete(readModel);
        }
    }
}
