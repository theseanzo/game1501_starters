using UnityEngine;

namespace Code.Scripts.FixedControl
{
    [CreateAssetMenu(fileName = "FixedPlayerData", menuName = "SO/FixedControl/PlayerData", order = 0)]
    public class FixedPlayerData : ScriptableObject
    {
        [field: SerializeField]
        public float Speed { get; private set; }
        [field: SerializeField]
        public float Acceleration { get; private set; }
    }
}