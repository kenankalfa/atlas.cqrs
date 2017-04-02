namespace Atlas.CommandHandlers
{
    using Atlas.Core;
    using Atlas.Domain;
    using Atlas.Storage;
    using Atlas.Commands;
    public class ChangeDiaryItemCommandHandler : ICommandHandler<ChangeDiaryItemCommand>
    {
        private readonly IAggregateRootRepository<DiaryItem> _repository;
        public ChangeDiaryItemCommandHandler(IAggregateRootRepository<DiaryItem> repository)
        {
            _repository = repository;
        }
        public void Execute(ChangeDiaryItemCommand command)
        {
            var aggregateRoot = _repository.GetById(command.AggregateId);
            
            if (aggregateRoot.Description != command.Description)
            {
                aggregateRoot.ChangeDescription(command.Description);
            }

            if (aggregateRoot.From != command.From)
            {
                aggregateRoot.ChangeFrom(command.From);
            }

            if (aggregateRoot.Title != command.Title)
            {
                aggregateRoot.ChangeTitle(command.Title);
            }

            if (aggregateRoot.To != command.To)
            {
                aggregateRoot.ChangeTo(command.To);
            }
            
            _repository.Save(aggregateRoot, aggregateRoot.Version);
        }
    }
}
