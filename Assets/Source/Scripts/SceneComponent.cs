using UnityEngine;

namespace Source.Scripts
{
    public class SceneComponent : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerSpawnPoint { get; private set; }
        [field: SerializeField] public UnityEngine.Camera MainCamera { get; private set; }
    }
}