using Leopotam.Ecs;
using Source.Scripts.Components;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private EcsFilter<PlayerComponent, PlayerInputComponent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(i);
                ref PlayerInputComponent playerInputComponent = ref _filter.Get2(i);

                float vertical = Vector3.Dot(playerInputComponent.MovementInput.normalized,
                    playerComponent.Transform.forward);
                float horizontal = Vector3.Dot(playerInputComponent.MovementInput.normalized,
                    playerComponent.Transform.right);

                playerComponent.Animator.SetFloat(Horizontal, horizontal, 0.1f, Time.deltaTime);
                playerComponent.Animator.SetFloat(Vertical, vertical, 0.1f, Time.deltaTime);
            }
        }
    }
}