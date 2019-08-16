using System;
using System.Collections.Generic;

public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
{
    private List<Action<T>> _subscribers = new List<Action<T>>();

    private T _value;
    
    public void Subscribe(Action<T> action)
    {
        _subscribers.Add(action);
        action.Invoke(_value);
    }

    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnNext(value);
        }
    }

    private void OnNext(T value)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Invoke(value);
        }
    }
}