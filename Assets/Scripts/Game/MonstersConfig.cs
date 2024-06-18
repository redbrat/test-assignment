using System;
using Game.Actors.Monsters;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class MonstersConfig
    {
        public MonsterVisualConfig RandomMonsterConfig => monsterPrefabs[UnityEngine.Random.Range(0, monsterPrefabs.Length)]; 
        
        [SerializeField] private MonsterVisualConfig[] monsterPrefabs;
    }
}
