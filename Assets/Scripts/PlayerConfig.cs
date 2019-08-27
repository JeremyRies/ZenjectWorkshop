using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject, IPlayerConfig
{
    [SerializeField] private float _speedFactor;

    public float SpeedFactor
    {
        get { return _speedFactor; }
    }
}