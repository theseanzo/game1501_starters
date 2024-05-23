using UnityEngine;

namespace Code.Scripts.FixedControl
{
    [CreateAssetMenu(fileName = "TankPlayerData", menuName = "SO/FixedControl/TankPlayerData", order = 0)]
    public class TankPlayerData : ScriptableObject
    {
        [field: SerializeField]
        public float MovementSpeed { get; private set; }
        [field: SerializeField]
        public float RotationSpeed { get; private set; }
        [field: SerializeField]
        public float Acceleration { get; private set; }
    }
}