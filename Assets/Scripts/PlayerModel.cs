using NUnit.Framework;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerModel : IPlayerModel
    {
        private readonly IInputProvider _inputProvider;
        private readonly IPlayerConfig _inputPlayerConfig;
        private ReactiveProperty<float> _playerYPosition;

        public IReadOnlyReactiveProperty<float> PlayerYPosition
        {
            get { return _playerYPosition; }
        }

        public PlayerModel(IUpdateManager updateManager, IInputProvider inputProvider, IPlayerConfig inputPlayerConfig)
        {
            _inputProvider = inputProvider;
            _inputPlayerConfig = inputPlayerConfig;
            _playerYPosition = new ReactiveProperty<float>();

            updateManager.Subscribe(UpdateLoop);
        }

        private void UpdateLoop()
        {
            _playerYPosition.Value += _inputPlayerConfig.SpeedFactor * Time.deltaTime * _inputProvider.VerticalInput();
        }
    }
}