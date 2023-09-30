using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using Source.Scripts.Weapon.Components;
using UnityEngine;

namespace Source.Scripts.Player.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";


        private EcsFilter<PlayerInput, HasWeapon> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref PlayerInput playerInput = ref _filter.Get1(i);
                ref HasWeapon hasWeapon = ref _filter.Get2(i);

                playerInput.MovementInput =
                    new Vector3(Input.GetAxisRaw(Horizontal), 0f, Input.GetAxisRaw(Vertical));
                playerInput.MovementInput.Normalize();

                playerInput.ShootInput = Input.GetMouseButtonDown(0);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    ref Weapon.Components.Weapon weapon = ref hasWeapon.Weapon.Get<Weapon.Components.Weapon>();

                    if (weapon.CurrentInMagazine >= weapon.MaxInMagazine)
                    {
                        continue;
                    }

                    ref EcsEntity entity = ref _filter.GetEntity(i);
                    entity.Get<TryReload>();
                }
            }
        }
    }
}