﻿namespace Atlas.Core
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;
    }
}
