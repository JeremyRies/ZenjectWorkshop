using UnityEngine;

public class InputProvider : IInputProvider
{
    public float VerticalInput()
    {
        return Input.GetAxis("Vertical");
    }
}