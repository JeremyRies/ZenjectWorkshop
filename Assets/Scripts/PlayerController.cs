public class PlayerController
{
    private readonly IPlayerModel _playerModel;

    public PlayerController(IPlayerModel playerModel, PlayerView view)
    {
        _playerModel = playerModel;
        _playerModel.PlayerPosition.Subscribe(pos => view.Position = pos);
    }
}