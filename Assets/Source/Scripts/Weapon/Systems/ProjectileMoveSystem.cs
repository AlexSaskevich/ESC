using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;
using UnityEngine;

namespace Source.Scripts.Weapon.Systems
{
    public class ProjectileMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Projectile> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref Projectile projectile = ref _filter.Get1(i);

                Vector3 position = projectile.ProjectileGameObject.transform.position;
                position += projectile.Direction * projectile.Speed * Time.deltaTime;
                projectile.ProjectileGameObject.transform.position = position;

                Vector3 displacementSinceLastFrame = position - projectile.PreviousPosition;
                
                bool hit = Physics.SphereCast(projectile.PreviousPosition, projectile.Radius,
                    displacementSinceLastFrame.normalized, out RaycastHit hitInfo,
                    displacementSinceLastFrame.magnitude);
                
                if (hit)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(i);
                    ref ProjectileHit projectileHit = ref entity.Get<ProjectileHit>();
                    projectileHit.RaycastHit = hitInfo;
                }

                projectile.PreviousPosition = projectile.ProjectileGameObject.transform.position;
            }
        }
    }
}