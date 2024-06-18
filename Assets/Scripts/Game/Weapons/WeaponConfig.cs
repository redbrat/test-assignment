using System;
using Game.Projectiles;
using UnityEngine;

namespace Game.Weapons
{
    [Serializable]
    public class WeaponConfig
    {
        public float Cooldown => cooldown;
        public Sprite Icon => icon;
        public ProjectileView ProjectilePrefab => projectilePrefab;

        [SerializeField] private float cooldown = 0.1f;
        [SerializeField] private Sprite icon;
        [SerializeField] private ProjectileView projectilePrefab;
    }
}
