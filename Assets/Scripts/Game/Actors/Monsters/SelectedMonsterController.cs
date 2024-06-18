using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Game.Actors.Monsters
{
    [UsedImplicitly]
    public class SelectedMonsterController
    {
        public MonsterView SelectedMonster { get; private set; }
        public event Action<MonsterView> MonsterSelected; 

        private readonly List<MonsterView> monsters = new ();
        private readonly List<MonsterVisualConfig> visualConfigs = new ();

        private int currentMonsterIndex;
        
        public void RegisterMonster(MonsterView monster, MonsterVisualConfig visualConfig)
        {
            if (!monsters.Contains(monster))
            {
                monsters.Add(monster);
                visualConfigs.Add(visualConfig);
            }
        }

        public void UnregisterMonster(MonsterView monster)
        {
            var index = monsters.IndexOf(monster);
            if (index < 0)
            {
                return;
            }

            monsters.RemoveAt(index);
            visualConfigs.RemoveAt(index);

            if (index == currentMonsterIndex)
            {
                SetSelectedMonster(null);
            }
        }

        public void CycleThroughMonsters(int cycleDirection)
        {
            if (monsters.Count == 0)
            {
                return;
            }

            currentMonsterIndex = (monsters.Count + currentMonsterIndex + cycleDirection) % monsters.Count;
            SetSelectedMonster(monsters[currentMonsterIndex]);
        }

        private void SetSelectedMonster(MonsterView monster)
        {
            SelectedMonster = monster;
            MonsterSelected?.Invoke(monster);
        }

        public MonsterVisualConfig GetVisualConfigForMonster(MonsterView monsterView)
        {
            var index = monsters.IndexOf(monsterView);
            if (index < 0)
            {
                return null;
            }

            return visualConfigs[index];
        }
    }
}
