namespace Atlas.Core
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetCommandHandler<T>() where T : ICommand;
    }
}
