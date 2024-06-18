using Game.Actors;
using Game.PlayingField;
using UnityEngine;
using Zenject;

namespace Game.Projectiles
{
    public class ProjectileView : MonoBehaviour, ITickable, IPositionHandler
    {
        private const float PROJECTILE_TRIGGERING_DISTANCE = 0.5f;

        public Vector3 WorldPosition => transform.position;
        
        [Inject] private readonly ProjectileConfig config;
        
        private IAttackable target;
        private bool isMoving;
        private float lifetime;
        private Vector3 lastNormalizedDirectionToTarget;
        
        public void Shoot()
        {
            isMoving = true;
        }

        public void Tick()
        {
            if (!isMoving)
            {
                return;
            }

            UpdatePosition();
            CheckLifetime();

            if (target.IsDestroyed)
            {
                return;
            }
            
            CheckTriggering();
        }

        private void CheckLifetime()
        {
            lifetime += Time.deltaTime;
            if (lifetime >= config.LifeTime)
            {
                Destroy(gameObject);
            }
        }

        private void CheckTriggering()
        {
            var distance = Vector3.Distance(transform.position, target.WorldPosition);
            if (distance <= PROJECTILE_TRIGGERING_DISTANCE)
            {
                target.ReceiveDamage(config.Damage);
                Destroy(gameObject);
            }
        }

        private void UpdatePosition()
        {
            switch (config.TrajectoryType)
            {
                case TrajectoryType.StraightLine:
                    DoStraightLinePositionUpdate();
                    break;
                case TrajectoryType.LockOnTarget:
                    DoLockOnTargetPositionUpdate();
                    break;
            }
        }

        private void DoLockOnTargetPositionUpdate()
        {
            if (!target.IsDestroyed)
            {
                UpdateDirectionToTarget();
            }
            
            DoStraightLinePositionUpdate();
        }

        private void UpdateDirectionToTarget()
        {
            lastNormalizedDirectionToTarget = (target.WorldPosition - transform.position).normalized;
        }

        private void DoStraightLinePositionUpdate()
        {
            var newPosition = WorldPosition + lastNormalizedDirectionToTarget * Time.deltaTime * config.Speed;
            SetPosition(newPosition);
        }

        public void SetTarget(IAttackable target)
        {
            this.target = target;
            UpdateDirectionToTarget();
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
