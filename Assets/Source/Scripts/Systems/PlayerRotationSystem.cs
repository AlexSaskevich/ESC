using Leopotam.Ecs;
using Source.Scripts.Components;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> _filter;
        private SceneComponent _sceneComponent;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(i);

                Plane playerPlane = new(Vector3.up, playerComponent.Transform.position);
                Ray ray = _sceneComponent.MainCamera.ScreenPointToRay(Input.mousePosition);

                if (playerPlane.Raycast(ray, out float hitDistance) == false)
                {
                    continue;
                }

                playerComponent.Transform.forward = ray.GetPoint(hitDistance) - playerComponent.Transform.position;
            }
        }
    }
}