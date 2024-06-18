using CompositionRoot.Factories;
using Game;
using Game.Actors;
using Game.Actors.Hero;
using Game.Actors.Monsters;
using Game.PlayingField;
using Game.Projectiles;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private HeroView heroView;
        [SerializeField] private SelectedMonsterGizmoView selectedMonsterGizmoView;
        
        public override void InstallBindings()
        {
            Container.Bind<IFactory<Vector3, IAttackable, ProjectileView, ProjectileView>>().To<ProjectileFactory>()
                .AsSingle();
            Container.Bind<IFactory<MonsterVisualConfig, MonsterView>>().To<MonsterFactory>().AsSingle();

            Container.Bind<PlayingFieldController>().AsSingle();
            Container.Bind<SelectedMonsterController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInstance(heroView);
            Container.BindInterfacesAndSelfTo<SelectedMonsterGizmoView>().FromInstance(selectedMonsterGizmoView);
        }
    }
}
