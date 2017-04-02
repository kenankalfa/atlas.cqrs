using System.Collections.Generic;

namespace Atlas.Core
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetEventHandler<T>() where T : IEvent;
    }
}
