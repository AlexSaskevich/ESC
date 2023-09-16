using UnityEngine;

namespace Source.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public GameObject PlayerPrefab { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }
    }
}