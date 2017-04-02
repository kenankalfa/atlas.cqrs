namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemTitleChangedEventHandler : IEventHandler<DiaryItemTitleChangedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemTitleChangedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }

        public void Handle(DiaryItemTitleChangedEvent @event)
        {
            var readModel = _repository.Get(@event.AggregateId);
            readModel.Title = @event.Title;
            readModel.Version = @event.Version;
            _repository.Update(readModel);
        }
    }
}
