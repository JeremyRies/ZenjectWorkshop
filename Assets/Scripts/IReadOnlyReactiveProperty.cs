using System;

namespace Scripts
{
    public interface IReadOnlyReactiveProperty<T>
    {
        T Value { get; }
        void Subscribe(Action<T> action);
    }
}