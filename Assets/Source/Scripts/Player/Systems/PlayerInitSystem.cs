using Leopotam.Ecs;
using Source.Scripts.Player.Components;
using Source.Scripts.ScriptableObjects;
using Source.Scripts.Weapon.Components;
using UnityEngine;

namespace Source.Scripts.Player.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private Setup _setup;
        private SceneComponent _sceneComponent;

        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref Components.Player player = ref playerEntity.Get<Components.Player>();
            ref HasWeapon hasWeapon = ref playerEntity.Get<HasWeapon>();
            ref PlayerInput playerInput = ref playerEntity.Get<PlayerInput>();
            ref AnimatorReference animatorReference = ref playerEntity.Get<AnimatorReference>();

            GameObject playerGameObject = SpawnPlayerGameObject();
            player = InitPlayer(playerGameObject);
            animatorReference.Animator = player.Animator;
            playerGameObject.GetComponent<PlayerView>().Entity = playerEntity;

            EcsEntity weaponEntity = _ecsWorld.NewEntity();
            ref Weapon.Components.Weapon weapon = ref weaponEntity.Get<Weapon.Components.Weapon>();
            WeaponSettings weaponSettings = playerGameObject.GetComponentInChildren<WeaponSettings>();

            hasWeapon.Weapon = weaponEntity;
            weapon = InitWeapon(playerEntity, weaponSettings);
        }

        private Weapon.Components.Weapon InitWeapon(EcsEntity playerEntity, WeaponSettings weaponSettings)
        {
            Weapon.Components.Weapon weapon;
            weapon.Owner = playerEntity;
            weapon.ProjectilePrefab = weaponSettings.ProjectilePrefab;
            weapon.ProjectileRadius = weaponSettings.ProjectileRadius;
            weapon.ProjectileSocket = weaponSettings.ProjectileSocket;
            weapon.ProjectileSpeed = weaponSettings.ProjectileSpeed;
            weapon.TotalAmmo = weaponSettings.TotalAmmo;
            weapon.WeaponDamage = weaponSettings.WeaponDamage;
            weapon.CurrentInMagazine = weaponSettings.CurrentInMagazine;
            weapon.MaxInMagazine = weaponSettings.MaxInMagazine;
            return weapon;
        }

        private GameObject SpawnPlayerGameObject()
        {
            return Object.Instantiate(_setup.PlayerPrefab, _sceneComponent.PlayerSpawnPoint.position,
                Quaternion.identity);
        }

        private Components.Player InitPlayer(GameObject playerGameObject)
        {
            Components.Player player;
            player.MoveSpeed = _setup.PlayerSpeed;
            player.Transform = playerGameObject.transform;
            player.CharacterController = playerGameObject.GetComponent<CharacterController>();
            player.Animator = playerGameObject.GetComponent<Animator>();
            return player;
        }
    }
}