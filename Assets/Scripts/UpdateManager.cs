using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour, IUpdateManager
{
    private readonly List<Action> _updateFunctions = new List<Action>();
    private void Update()
    {
        foreach (var updateFunction in _updateFunctions)
        {
            updateFunction.Invoke();
        }
    }

    public void SubscribeToUpdate(Action updateFunction)
    {
        _updateFunctions.Add(updateFunction);
    }
}