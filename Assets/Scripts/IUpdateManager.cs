using System;

namespace Assets.Scripts
{
    public interface IUpdateManager
    {
        void Subscribe(Action action);
    }
}