using System;
using UnityEngine;

namespace Game.Projectiles
{
    [Serializable]
    public class ProjectileConfig
    {
        public float Speed => speed;
        public float LifeTime => lifetime;
        public float Damage => damage;
        public TrajectoryType TrajectoryType => trajectoryType;
        
        [SerializeField] private float speed = 5f;
        [SerializeField] private float lifetime = 5f;
        [SerializeField] private float damage = 1f;
        [SerializeField] private TrajectoryType trajectoryType;
    }
}
