using Game.Actors;
using Game.Actors.Monsters;
using Game.Actors.Monsters.MonsterStates;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Factories
{
    [UsedImplicitly]
    public class MonsterStatesFactory : IFactory<MonsterState, IMonsterState>
    {
        [Inject] private readonly DiContainer diContainer;
        
        public IMonsterState Create(MonsterState state)
        {
            switch (state)
            {
                case MonsterState.AttackTheHero:
                    return diContainer.Instantiate<AttackTheHeroState>();
                case MonsterState.WalkTowardsHeroAndWaitForCooldown:
                    return diContainer.Instantiate<WalkTowardsHeroAndWaitForCooldownState>();
            }

            Debug.LogError($"[{nameof(MonsterStatesFactory)}] Don't know how to create a state of {state}!");
            return default;
        }
    }
}
