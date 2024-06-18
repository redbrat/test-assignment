using System;
using Game.Actors.Monsters;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class GameManager : ITickable
    {
        public event Action<int> MonstersCountChanged;
        public event Action GameEnd;
        
        public int MonstersCount { get; private set; }

        [Inject] private readonly GameConfig gameConfig;
        [Inject] private readonly IFactory<MonsterVisualConfig, MonsterView> monsterFactory;
        [Inject] private readonly MonstersConfig monstersConfig;
        [Inject] private readonly SelectedMonsterController selectedMonsterController;

        private float cooldown;
        
        public void Tick()
        {
            if (cooldown <= 0 && MonstersCount < gameConfig.MaximumMonsterCount)
            {
                cooldown = gameConfig.MonsterSpawnCooldown;
                var randomConfig = monstersConfig.RandomMonsterConfig;
                var monster = monsterFactory.Create(randomConfig);
                selectedMonsterController.RegisterMonster(monster, randomConfig);
                MonstersCount++;
                MonstersCountChanged?.Invoke(MonstersCount);
            }

            cooldown -= Time.deltaTime;
        }

        public void MonsterHasBeenKilled()
        {
            MonstersCount--;
        }

        public void HeroIsDead()
        {
            GameEnd?.Invoke();
            Time.timeScale = 0f;
        }
    }
}
