using System.Collections.Generic;

namespace Atlas.Core
{
    public interface IEventProvider
    {
        IEnumerable<IEvent> GetUncommitedChanges();
        void LoadsFromHistory(IEnumerable<IEvent> history);
    }
}
