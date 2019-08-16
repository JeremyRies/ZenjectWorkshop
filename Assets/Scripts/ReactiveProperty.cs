using System;
using System.Collections.Generic;

namespace Scripts
{
    public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>
    {
        private readonly List<Action<T>> _subscriptions = new List<Action<T>>();

        private T _value;

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
            _subscriptions.ForEach(subscription => subscription.Invoke(value));
        }

        public void Subscribe(Action<T> action)
        {
            _subscriptions.Add(action);
            action.Invoke(Value);
        }
    }
}