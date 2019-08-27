public class PlayerController
{
    public PlayerController(IPlayerModel playerModel, PlayerView playerView)
    {
        playerModel.PlayerYPosition.Subscribe(playerView.SetPosition);
    }
}