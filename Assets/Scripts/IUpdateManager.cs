using System;

public interface IUpdateManager
{
    void SubscribeToUpdate(Action updateFunction);
}