using UnityEngine;

namespace Source.Scripts.Components
{
    public class SceneComponent : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
        [field: SerializeField] public Camera MainCamera { get; private set; }
    }
}