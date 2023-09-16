using Leopotam.Ecs;
using Source.Scripts.Components;
using Source.Scripts.ScriptableObjects;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneComponent _sceneComponent;

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref PlayerComponent playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref PlayerInputComponent playerInputComponent = ref playerEntity.Get<PlayerInputComponent>();

            GameObject playerGameObject = Object.Instantiate(_staticData.PlayerPrefab,
                _sceneComponent.PlayerSpawnPoint.position, Quaternion.identity);
            
            playerComponent.MoveSpeed = _staticData.PlayerSpeed;
            playerComponent.Transform = playerGameObject.transform;
            playerComponent.CharacterController = playerGameObject.GetComponent<CharacterController>();
        }
    }
}