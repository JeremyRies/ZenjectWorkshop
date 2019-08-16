public class PlayerController
{
    public PlayerController(PlayerModel model, PlayerView view)
    {
        model.PlayerYPosition.Subscribe(view.SetPosition);
    }
}