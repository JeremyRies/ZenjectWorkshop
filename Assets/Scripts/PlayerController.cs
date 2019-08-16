namespace Scripts
{
    public class PlayerController
    {
        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            playerModel.PlayerYPosition.Subscribe(playerView.SetPosition);
        }
    }
}