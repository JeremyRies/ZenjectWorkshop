using UnityEngine;

namespace Scripts
{
    public class PlayerView : MonoBehaviour
    {
        public void SetPosition(int pos)
        {
            transform.position = new Vector3(0, pos, 0);
        }
    }
}