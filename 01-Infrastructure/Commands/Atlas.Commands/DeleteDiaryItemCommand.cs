using System;

namespace Atlas.Commands
{
    using Atlas.Core;
    public class DeleteDiaryItemCommand : Command
    {
        public DeleteDiaryItemCommand(Guid AggregateId,int version) : base(AggregateId,version)
        {

        }
    }
}
