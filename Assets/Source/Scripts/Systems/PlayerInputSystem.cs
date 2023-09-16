using Leopotam.Ecs;
using Source.Scripts.Components;
using UnityEngine;

namespace Source.Scripts.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private EcsFilter<PlayerInputComponent> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerInputComponent playerInputComponent = ref _filter.Get1(i);
                playerInputComponent.MovementInput = new Vector3(Input.GetAxisRaw(Horizontal), 0f, Input.GetAxisRaw(Vertical));
                playerInputComponent.MovementInput.Normalize();
            }
        }
    }
}