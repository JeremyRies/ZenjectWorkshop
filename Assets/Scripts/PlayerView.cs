using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float Position
    {
        set
        {
            transform.position += new Vector3(0,value,0);
        }
    }
}