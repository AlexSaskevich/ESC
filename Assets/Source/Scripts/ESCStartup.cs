using Leopotam.Ecs;
using Source.Scripts.Components;
using Source.Scripts.ScriptableObjects;
using Source.Scripts.Services;
using Source.Scripts.Systems;
using UnityEngine;

namespace Source.Scripts
{
    public class EscStartup : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        [field: SerializeField] public StaticData Configuration { get; private set; }
        [field: SerializeField] public SceneComponent SceneComponent { get; private set; }

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _updateSystems = new EcsSystems(_ecsWorld);
            _fixedUpdateSystems = new EcsSystems(_ecsWorld);

            RuntimeData runtimeData = new();

            _updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerRotationSystem())
                .Add(new PlayerMovementSystem())
                .Inject(Configuration)
                .Inject(SceneComponent)
                .Inject(runtimeData);

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
            _ecsWorld?.Destroy();
            _ecsWorld = null;
        }
    }
}