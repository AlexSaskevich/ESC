using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;

namespace Source.Scripts.Weapon.Systems
{
    public class ProjectileHitSystem : IEcsRunSystem
    {
        private EcsFilter<Projectile, ProjectileHit> _filter;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Projectile projectile = ref _filter.Get1(i);
            
                projectile.ProjectileGameObject.SetActive(false);
            }
        }
    }
}