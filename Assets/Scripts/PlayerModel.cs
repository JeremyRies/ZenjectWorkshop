public class PlayerModel : IPlayerModel
{
    private readonly IPlayerInput _input;
    private readonly ReactiveProperty<float> _playerPosition = new ReactiveProperty<float>();

    public PlayerModel(IUpdateManager updateManager, IPlayerInput input)
    {
        _input = input;
        updateManager.SubscribeToUpdate(PlayerUpdate);
    }

    private void PlayerUpdate()
    {
        _playerPosition.Value += _input.GetMovement();
    }

    public IReadOnlyReactiveProperty<float> PlayerPosition
    {
        get { return _playerPosition; }
    }
}