using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour, IUpdateManager
{
    private readonly List<Action> _subscriber = new List<Action>();

    private void Update()
    {
        foreach (var action in _subscriber)
        {
            action.Invoke();
        }
    }

    public void Subscribe(Action action)
    {
        _subscriber.Add(action);
    }
}