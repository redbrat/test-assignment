using System;
using UnityEngine;

namespace Game.Actors.Hero
{
    [Serializable]
    public class HeroConfig
    {
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float Health => health;
        public float Defense => defense;
        
        [SerializeField] private float movementSpeed = 2.5f;
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private float health = 100f;
        [Range(0f, 1f)] private float defense = 0.5f;
    }
}
