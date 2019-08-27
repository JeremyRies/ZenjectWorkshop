using System;

public interface IUpdateManager
{
    void Subscribe(Action action);
}