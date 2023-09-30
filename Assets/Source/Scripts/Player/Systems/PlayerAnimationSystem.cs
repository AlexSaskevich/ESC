using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using UnityEngine;

namespace Source.Scripts.Player.Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);
        private const string IsShooting = nameof(IsShooting);
        private const float DampTime = 0.1f;

        private EcsFilter<Components.Player, PlayerInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Components.Player player = ref _filter.Get1(i);
                ref PlayerInput playerInput = ref _filter.Get2(i);

                float vertical = Vector3.Dot(playerInput.MovementInput.normalized,
                    player.Transform.forward);
                float horizontal = Vector3.Dot(playerInput.MovementInput.normalized,
                    player.Transform.right);

                player.Animator.SetFloat(Horizontal, horizontal, DampTime, Time.deltaTime);
                player.Animator.SetFloat(Vertical, vertical, DampTime, Time.deltaTime);
                player.Animator.SetBool(IsShooting, playerInput.ShootInput);
            }
        }
    }
}