using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class GameConfig
    {
        public int MaximumMonsterCount => maximumMonsterCount;
        public float MonsterSpawnCooldown => monsterSpawnCooldown;
        public Vector2 PlayingFieldExtents => playingFieldExtents;

        [SerializeField] private int maximumMonsterCount;
        [SerializeField] private float monsterSpawnCooldown;
        [SerializeField] private Vector2 playingFieldExtents;
    }
}
