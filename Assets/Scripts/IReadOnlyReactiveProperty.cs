using System;

public interface IReadOnlyReactiveProperty<T>
{
    void Subscribe(Action<T> action);
    T Value { get; }
}