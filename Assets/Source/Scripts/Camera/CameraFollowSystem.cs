using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using Source.Scripts.ScriptableObjects;
using UnityEngine;

namespace Source.Scripts.Camera
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<Player.Components.Player> _filter;
        private Setup _setup;
        private SceneComponent _sceneComponent;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Player.Components.Player player = ref _filter.Get1(i);

                Vector3 desiredPosition = player.Transform.position + _setup.CameraOffset;
                _sceneComponent.MainCamera.transform.position = Vector3.Lerp(
                    _sceneComponent.MainCamera.transform.position, desiredPosition,
                    1f / _setup.SmoothingCameraPower * Time.deltaTime);
            }
        }
    }
}