using Game.Actors;
using Game.Projectiles;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Factories
{
    [UsedImplicitly]
    public class ProjectileFactory : IFactory<Vector3, IAttackable, ProjectileView, ProjectileView>
    {
        [Inject] private readonly DiContainer diContainer;
        
        public ProjectileView Create(Vector3 position, IAttackable target, ProjectileView prefab)
        {
            var result = diContainer.InstantiatePrefabForComponent<ProjectileView>(prefab);
            result.SetPosition(position);
            result.SetTarget(target);
            return result;
        }
    }
}
