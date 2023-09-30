using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;
using UnityEngine;

namespace Source.Scripts.Weapon.Systems
{
    public class SpawnProjectileSystem : IEcsRunSystem
    {
        private EcsFilter<Components.Weapon, SpawnProjectile> _filter;
        private EcsWorld _ecsWorld;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Components.Weapon weapon = ref _filter.Get1(i);

                GameObject projectileGameObject = Object.Instantiate(weapon.ProjectilePrefab,
                    weapon.ProjectileSocket.position, Quaternion.identity);

                EcsEntity projectileEntity = _ecsWorld.NewEntity();

                ref Projectile projectile = ref projectileEntity.Get<Projectile>();

                projectile.Damage = weapon.WeaponDamage;
                projectile.Direction = weapon.ProjectileSocket.forward;
                projectile.Radius = weapon.ProjectileRadius;
                projectile.Speed = weapon.ProjectileSpeed;
                projectile.PreviousPosition = projectileGameObject.transform.position;
                projectile.ProjectileGameObject = projectileGameObject;

                ref EcsEntity entity = ref _filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
            }
        }
    }
}