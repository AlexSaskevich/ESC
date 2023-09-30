using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;

namespace Source.Scripts.Weapon.Systems
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsFilter<Components.Weapon, Shoot> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Components.Weapon weapon = ref _filter.Get1(i);

                ref EcsEntity entity = ref _filter.GetEntity(i);
                entity.Del<Shoot>();
            
                if (weapon.CurrentInMagazine > 0)
                {
                    weapon.CurrentInMagazine--;
                
                    ref SpawnProjectile spawnProjectile = ref entity.Get<SpawnProjectile>();
                }
                else 
                { 
                    ref TryReload tryReload = ref entity.Get<TryReload>();
                }
            }
        }
    }
}