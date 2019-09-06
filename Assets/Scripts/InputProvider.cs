using UnityEngine;

public class InputProvider : IInputProvider
{
    private readonly PlayerType _playerType;

    public InputProvider(PlayerType playerType)
    {
        _playerType = playerType;
    }

    public float VerticalInput()
    {
        return _playerType == PlayerType.Left ? Input.GetAxis("Vertical") : Input.GetAxis("Horizontal");
    }
}