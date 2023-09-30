using Leopotam.Ecs;
using Source.Scripts.Weapon.Components;
using UnityEngine;

namespace Source.Scripts.Player.Components
{
    public class PlayerView : MonoBehaviour
    {
        public EcsEntity Entity;

        public void Shoot()
        {
            Entity.Get<HasWeapon>().Weapon.Get<Shoot>();
        }

        public void Reload()
        {
            Entity.Get<HasWeapon>().Weapon.Get<ReloadingFinished>();
        }
    }
}