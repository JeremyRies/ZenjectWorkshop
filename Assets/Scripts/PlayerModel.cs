using UnityEngine;

public class PlayerModel : IPlayerModel
{
    private readonly IInputProvider _inputProvider;
    private readonly IPlayerConfig _playerConfig;
    private readonly ReactiveProperty<float> _playerYPosition;

    public IReadOnlyReactiveProperty<float> PlayerYPosition
    {
        get { return _playerYPosition; }
    }

    public PlayerModel(IUpdateManager updateManager, IInputProvider inputProvider, IPlayerConfig playerConfig)
    {
        _inputProvider = inputProvider;
        _playerConfig = playerConfig;
        _playerYPosition = new ReactiveProperty<float>();

        updateManager.Subscribe(UpdateLoop);
    }

    private void UpdateLoop()
    {
        _playerYPosition.Value += _inputProvider.VerticalInput() * _playerConfig.SpeedFactor * Time.deltaTime;
    }
}