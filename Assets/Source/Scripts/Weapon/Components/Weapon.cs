using Leopotam.Ecs;
using UnityEngine;

namespace Source.Scripts.Weapon.Components
{
    public struct Weapon
    {
        public EcsEntity Owner;
        public GameObject ProjectilePrefab;
        public Transform ProjectileSocket;
        public float ProjectileSpeed;
        public float ProjectileRadius;
        public int WeaponDamage;
        public int CurrentInMagazine;
        public int MaxInMagazine;
        public int TotalAmmo;
    }
}