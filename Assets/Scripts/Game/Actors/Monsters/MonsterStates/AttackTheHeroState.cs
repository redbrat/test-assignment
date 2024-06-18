using Game.Actors.Hero;
using Game.PlayingField;
using Game.Projectiles;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Actors.Monsters.MonsterStates
{
    [UsedImplicitly]
    public class AttackTheHeroState : IMonsterState
    {
        [Inject] private readonly MonsterConfig config;
        [Inject] private readonly HeroView heroView;
        [Inject] private readonly MonsterStateMachine stateMachine;
        [Inject] private readonly IFactory<Vector3, IAttackable, ProjectileView, ProjectileView> projectilesFactory;
        [Inject] private readonly IPositionHandler ouwPositionHandler;
        
        public void Update()
        {
            if (config.AttackRange == 0)
            {
                heroView.ReceiveDamage(config.MeleeAttackDamage);
            }
            else
            {
                var projectile = projectilesFactory.Create(ouwPositionHandler.WorldPosition, heroView,
                    config.ProjectilePrefab);
                projectile.Shoot();
            }
            stateMachine.GoToState(MonsterState.WalkTowardsHeroAndWaitForCooldown);
        }
    }
}
