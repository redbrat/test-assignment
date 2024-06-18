using System;
using UnityEngine;

namespace Game.Actors.Monsters
{
    [Serializable]
    public class MonsterVisualConfig
    {
        public Sprite Icon => icon;
        public MonsterView ViewPrefab => viewPrefab;
        
        [SerializeField] private Sprite icon;
        [SerializeField] private MonsterView viewPrefab;
    }
}
