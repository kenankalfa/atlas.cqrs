namespace Atlas.CommandHandlers
{
    using Atlas.Core;
    using Atlas.Domain;
    using Atlas.Storage;
    using Atlas.Commands;
    public class CreateDiaryItemCommandHandler : ICommandHandler<CreateDiaryItemCommand>
    {
        private readonly IAggregateRootRepository<DiaryItem> _repository;
        public CreateDiaryItemCommandHandler(IAggregateRootRepository<DiaryItem> repository)
        {
            _repository = repository;
        }
        public void Execute(CreateDiaryItemCommand command)
        {
            var aggregateRoot = new DiaryItem(command.AggregateId, command.Title, command.Description, command.From, command.To);
            aggregateRoot.Version = -1;
            _repository.Save(aggregateRoot, aggregateRoot.Version);
        }
    }
}
