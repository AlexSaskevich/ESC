using Leopotam.Ecs;
using Source.Scripts.Components;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputComponent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerComponent playerComponent = ref _filter.Get1(i);
                ref PlayerInputComponent input = ref _filter.Get2(i);

                Vector3 direction = new(input.MovementInput.x, 0f, input.MovementInput.z);
                direction *= playerComponent.MoveSpeed;
                playerComponent.CharacterController.SimpleMove(direction);
            }
        }
    }
}