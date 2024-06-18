using Game.Actors.Hero;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Actors.Monsters.MonsterStates
{
    [UsedImplicitly]
    public class WalkTowardsHeroAndWaitForCooldownState : IMonsterState
    {
        private const float MELEE_RANGE_MAXIMUM_DISTANCE = 0.25f;
        
        [Inject] private readonly MonsterConfig config;
        [Inject] private readonly HeroView heroView;
        [Inject] private readonly MonsterView ownView;
        [Inject] private readonly MonsterStateMachine stateMachine;

        private float attackCooldown;

        [Inject]
        private void Init()
        {
            attackCooldown = config.AttackCooldown;
        }
        
        public void Update()
        {
            attackCooldown -= Time.deltaTime;
            
            var distanceToHero = Vector3.Distance(heroView.WorldPosition, ownView.WorldPosition);
            if (distanceToHero > config.AttackRange + MELEE_RANGE_MAXIMUM_DISTANCE)
            {
                MoveTowardsHero();
            }
            else if (attackCooldown <= 0)
            {
                stateMachine.GoToState(MonsterState.AttackTheHero);
            }
        }

        private void MoveTowardsHero()
        {
            var heroVector = heroView.WorldPosition - ownView.WorldPosition;
            var step = heroVector.normalized * Time.deltaTime * config.Speed;
            ownView.SetPosition(ownView.WorldPosition + step);
        }
    }
}
