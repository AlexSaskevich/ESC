using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using UnityEngine;

namespace Source.Scripts.Player.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private EcsFilter<Components.Player, PlayerInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Components.Player player = ref _filter.Get1(i);
                ref PlayerInput input = ref _filter.Get2(i);

                Vector3 direction = new(input.MovementInput.x, 0f, input.MovementInput.z);
                direction *= player.MoveSpeed;
                player.CharacterController.SimpleMove(direction);
            }
        }
    }
}