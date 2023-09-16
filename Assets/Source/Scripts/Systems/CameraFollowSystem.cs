using Leopotam.Ecs;
using Source.Scripts.Components;
using Source.Scripts.ScriptableObjects;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> _filter;
        private Setup _setup;
        private SceneComponent _sceneComponent;


        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(i);

                Vector3 desiredPosition = playerComponent.Transform.position + _setup.CameraOffset;
                _sceneComponent.MainCamera.transform.position = Vector3.Lerp(
                    _sceneComponent.MainCamera.transform.position, desiredPosition,
                    1f / _setup.SmoothingCameraPower * Time.deltaTime);
            }
        }
    }
}