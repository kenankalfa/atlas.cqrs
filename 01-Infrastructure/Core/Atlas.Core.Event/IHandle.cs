namespace Atlas.Core
{
    public interface IHandle<T> where T : IEvent
    {
        void Handle(T @event);
    }
}
