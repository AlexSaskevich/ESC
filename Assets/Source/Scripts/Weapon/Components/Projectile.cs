using UnityEngine;

namespace Source.Scripts.Weapon.Components
{
    public struct Projectile
    {
        public Vector3 Direction;
        public Vector3 PreviousPosition;
        public GameObject ProjectileGameObject;
        public float Speed;
        public float Radius;
        public int Damage;
    }
}