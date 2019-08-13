using System;
using System.Collections.Generic;

public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
{
    private T _value;
    private readonly List<Action<T>> _actions = new List<Action<T>>();

    public void Subscribe(Action<T> onNext)
    {
        _actions.Add(onNext);
    }

    public T Value
    {
        get { return _value; }
        set
        {
            _value = value;
            foreach (var action in _actions)
            {
                action.Invoke(_value);
            }
        }
    }
}