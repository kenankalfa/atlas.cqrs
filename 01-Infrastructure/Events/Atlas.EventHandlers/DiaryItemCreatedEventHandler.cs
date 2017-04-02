namespace Atlas.EventHandlers
{
    using Atlas.Core;
    using Atlas.Events;
    using Atlas.Storage;
    using Atlas.ReadModels;
    public class DiaryItemCreatedEventHandler : IEventHandler<DiaryItemCreatedEvent>
    {
        private readonly IReportingRepository<DiaryItemReadModel> _repository;
        public DiaryItemCreatedEventHandler(IReportingRepository<DiaryItemReadModel> repository)
        {
            _repository = repository;
        }
        public void Handle(DiaryItemCreatedEvent @event)
        {
            var readModel = new DiaryItemReadModel();

            readModel.Description = @event.Description;
            readModel.From = @event.From;
            readModel.Id = @event.AggregateId;
            readModel.Title = @event.Title;
            readModel.To = @event.To;
            readModel.Version = -1;

            _repository.Create(readModel);
        }
    }
}
