using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject, IPlayerConfig
{
    [SerializeField] private float _speedfactor;

    public float Speedfactor
    {
        get { return _speedfactor; }
    }
}