using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public float GetMovement()
    {
        return Input.GetAxis("Vertical");
    }
}