using CompositionRoot.Factories;
using Game.Actors.Monsters;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    [UsedImplicitly]
    public class MonsterInstaller : MonoInstaller
    {
        [SerializeField] private MonsterConfig config;
        [SerializeField] private MonsterView monsterView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(config);
            Container.BindInterfacesAndSelfTo<MonsterView>().FromInstance(monsterView);
            Container.Bind<IFactory<MonsterState, IMonsterState>>().To<MonsterStatesFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<MonsterStateMachine>().AsSingle().NonLazy();
        }
    }
}
