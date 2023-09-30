using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using UnityEngine;

namespace Source.Scripts.Player.Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Components.Player> _filter;
        private SceneComponent _sceneComponent;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Components.Player player = ref _filter.Get1(i);

                Plane playerPlane = new(Vector3.up, player.Transform.position);
                Ray ray = _sceneComponent.MainCamera.ScreenPointToRay(Input.mousePosition);

                if (playerPlane.Raycast(ray, out float hitDistance) == false)
                {
                    continue;
                }

                player.Transform.forward = ray.GetPoint(hitDistance) - player.Transform.position;
            }
        }
    }
}