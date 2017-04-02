using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Core
{
    public class CommandBus : ICommandBus
    {
        private ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public virtual void Send<T>(T command) where T : ICommand
        {
            var commandHandler = _commandHandlerFactory.GetCommandHandler<T>();

            if (commandHandler != null)
            {
                commandHandler.Execute(command);
            }
        }
    }
}
