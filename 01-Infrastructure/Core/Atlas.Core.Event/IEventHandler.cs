namespace Atlas.Core
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T @event);
    }
}
