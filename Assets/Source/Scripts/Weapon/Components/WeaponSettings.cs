using UnityEngine;

namespace Source.Scripts.Weapon.Components
{
    public class WeaponSettings : MonoBehaviour
    {
        [field: SerializeField] public GameObject ProjectilePrefab { get; private set; }
        [field: SerializeField] public Transform ProjectileSocket { get; private set; }
        [field: SerializeField] public float ProjectileSpeed { get; private set; }
        [field: SerializeField] public float ProjectileRadius { get; private set; }
        [field: SerializeField] public int WeaponDamage { get; private set; }
        [field: SerializeField] public int CurrentInMagazine { get; private set; }
        [field: SerializeField] public int MaxInMagazine { get; private set; }
        [field: SerializeField] public int TotalAmmo { get; private set; }
    }
}