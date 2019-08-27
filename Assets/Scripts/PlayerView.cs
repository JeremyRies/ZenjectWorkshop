using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public void SetPosition(float pos)
    {
        transform.position = new Vector3(0,pos,0);
    }
}