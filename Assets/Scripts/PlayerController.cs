using UnityEngine;
using Zenject;

public class PlayerController : IInitializable
{
    public PlayerController(IPlayerModel model, PlayerView view)
    {
        Debug.Log(view);
        model.PlayerYPosition.Subscribe(view.SetPosition);
    }

    public void Initialize()
    {
        Debug.Log("asd");
    }
}