using Game.Actors.Monsters;
using Game.PlayingField;
using Game.Projectiles;
using Game.UI;
using Game.Weapons;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Actors.Hero
{
    [UsedImplicitly]
    public class HeroWeaponController : ITickable
    {
        [Inject] private readonly WeaponsConfig weaponsConfig;
        [Inject] private IPositionHandler ourPositionHandler;
        [Inject] private readonly WeaponUI weaponUI;
        [Inject] private readonly SelectedMonsterController selectedMonsterController;
        [Inject] private readonly IFactory<Vector3, IAttackable, ProjectileView, ProjectileView> projectilesFactory;

        private int currentWeaponIndex;
        private WeaponConfig currentWeapon;
        private float cooldown;

        [Inject]
        private void Init()
        {
            SetWeapon();
        }

        private void SetWeapon()
        {
            currentWeapon = weaponsConfig.WeaponConfigs[currentWeaponIndex];
            weaponUI.ShowWeapon(currentWeapon);
        }

        public void CycleWeapons(int cycleDirection)
        {
            currentWeaponIndex = (weaponsConfig.WeaponConfigs.Count + currentWeaponIndex + cycleDirection) %
                                 weaponsConfig.WeaponConfigs.Count;
            SetWeapon();
        }

        public void Shoot()
        {
            if (selectedMonsterController.SelectedMonster == null)
            {
                return;
            }

            if (cooldown > 0)
            {
                return;
            }

            var projectile = projectilesFactory.Create(ourPositionHandler.WorldPosition,
                selectedMonsterController.SelectedMonster, currentWeapon.ProjectilePrefab);
            projectile.Shoot();
            cooldown = currentWeapon.Cooldown;
        }

        public void Tick()
        {
            cooldown -= Time.deltaTime;
        }
    }
}
