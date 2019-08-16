namespace Scripts
{
    public class PlayerModel
    {
        private ReactiveProperty<int> _playerYPosition;

        public IReadOnlyReactiveProperty<int> PlayerYPosition
        {
            get { return _playerYPosition; }
        }

        public PlayerModel()
        {
            _playerYPosition = new ReactiveProperty<int>();
            _playerYPosition.Value = 5;
        }
    }
}