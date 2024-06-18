using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapons
{
    [Serializable]
    public class WeaponsConfig
    {
        public IReadOnlyList<WeaponConfig> WeaponConfigs => weaponConfigs;

        [SerializeField] private WeaponConfig[] weaponConfigs;
    }
}
