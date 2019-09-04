using UnityEngine;

public class InputProvider : IInputProvider
{
    private readonly PlayerType _type;

    public InputProvider(PlayerType type)
    {
        _type = type;
        Debug.Log("Input Setup for" +  type);
    }
    public float VerticalInput()
    {
        return _type == PlayerType.left ? Input.GetAxis("Vertical") : Input.GetAxis("Horizontal");
    }
}