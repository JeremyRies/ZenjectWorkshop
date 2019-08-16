using UnityEngine;

public class PlayerModel
{
    private ReactiveProperty<int> _playerYPosition;

    public IReadOnlyReactiveProperty<int> PlayerYPosition
    {
        get { return _playerYPosition; }
    }

    public PlayerModel()
    {
        Debug.Log("PlayerModel Created");
        _playerYPosition = new ReactiveProperty<int>();
        _playerYPosition.Value = 5;
    }
}