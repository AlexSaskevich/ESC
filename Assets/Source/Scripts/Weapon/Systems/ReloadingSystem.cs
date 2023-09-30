using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;

namespace Source.Scripts.Weapon.Systems
{
    public class ReloadingSystem : IEcsRunSystem
    {
        private const string Reload = nameof(Reload);

        private EcsFilter<TryReload, AnimatorReference> _tryReloadFilter;
        private EcsFilter<Components.Weapon, ReloadingFinished> _reloadingFinishedFilter;

        public void Run()
        {
            foreach (int i in _tryReloadFilter)
            {
                ref AnimatorReference animatorReference = ref _tryReloadFilter.Get2(i);

                animatorReference.Animator.SetTrigger(Reload);

                ref EcsEntity entity = ref _tryReloadFilter.GetEntity(i);
                entity.Del<TryReload>();
            }

            foreach (int i in _reloadingFinishedFilter)
            {
                ref Components.Weapon weapon = ref _reloadingFinishedFilter.Get1(i);

                int needAmmo = weapon.MaxInMagazine - weapon.CurrentInMagazine;

                weapon.CurrentInMagazine = weapon.TotalAmmo >= needAmmo
                    ? weapon.MaxInMagazine
                    : weapon.CurrentInMagazine + weapon.TotalAmmo;

                weapon.TotalAmmo -= needAmmo;
                weapon.TotalAmmo = weapon.TotalAmmo < 0 ? 0 : weapon.TotalAmmo;

                ref EcsEntity entity = ref _reloadingFinishedFilter.GetEntity(i);
                entity.Del<ReloadingFinished>();
            }
        }
    }
}