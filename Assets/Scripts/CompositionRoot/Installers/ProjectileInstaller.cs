using Game.Projectiles;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    public class ProjectileInstaller : MonoInstaller
    {
        [SerializeField] private ProjectileView projectileView;
        [SerializeField] private ProjectileConfig projectileConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(projectileConfig);
            Container.BindInterfacesAndSelfTo<ProjectileView>().FromInstance(projectileView);
        }
    }
}
