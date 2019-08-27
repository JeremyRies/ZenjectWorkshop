using Assets.Scripts;

public class PlayerController
{
    public PlayerController(IPlayerModel model, PlayerView view)
    {
        model.PlayerYPosition.Subscribe(view.SetPosition);
    }
}