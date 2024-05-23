using UnityEngine;

namespace Code.Scripts.FixedControl
{
    [CreateAssetMenu(fileName = "PointClickPlayerData", menuName = "SO/FixedControl/PointClickPlayerData", order = 2)]
    public class PointClickPlayerData : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; }
        
    }
}