using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour, IUpdateManager
{
    private List<Action> _updateFunctions;
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