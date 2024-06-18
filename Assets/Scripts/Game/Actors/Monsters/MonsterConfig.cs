using System;
using Game.Projectiles;
using UnityEngine;

namespace Game.Actors.Monsters
{
    [Serializable]
    public class MonsterConfig
    {
        public float Speed => speed;
        public float AttackRange => attackRange;
        public float MeleeAttackDamage => meleeAttackDamage;
        public float AttackCooldown => attackCooldown;
        public float Health => health;
        public float Defense => defense;
        public ProjectileView ProjectilePrefab => projectilePrefab;
        
        [SerializeField] private float speed = 1f;
        [SerializeField] private float attackRange = 10f;
        [SerializeField] private float meleeAttackDamage = 10f;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float health = 5f;
        [SerializeField, Range(0, 1)] private float defense = 0.25f;
        [SerializeField] private ProjectileView projectilePrefab;
    }
}
