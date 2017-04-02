namespace Atlas.CommandHandlers
{
    using Atlas.Core;
    using Atlas.Domain;
    using Atlas.Storage;
    using Atlas.Commands;
    public class DeleteDiaryItemCommandHandler : ICommandHandler<DeleteDiaryItemCommand>
    {
        private readonly IAggregateRootRepository<DiaryItem> _repository;
        public DeleteDiaryItemCommandHandler(IAggregateRootRepository<DiaryItem> repository)
        {
            _repository = repository;
        }
        public void Execute(DeleteDiaryItemCommand command)
        {
            var aggregateRoot = _repository.GetById(command.AggregateId);
            aggregateRoot.Delete();
            _repository.Save(aggregateRoot, aggregateRoot.Version);

        }
    }
}
