using UnityEngine;

namespace Source.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class Setup : ScriptableObject
    {
        [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public Vector3 CameraOffset { get; private set; }
        [field: SerializeField] public float SmoothingCameraPower { get; private set; }
    }
}