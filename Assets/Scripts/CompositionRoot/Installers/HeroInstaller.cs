using Game.Actors.Hero;
using Game.Weapons;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    public class HeroInstaller : MonoInstaller
    {
        [SerializeField] private HeroView heroView;
        [SerializeField] private HeroConfig heroConfig;
        [SerializeField] private WeaponsConfig weaponsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(weaponsConfig);
            Container.BindInstance(heroConfig);
            Container.BindInterfacesAndSelfTo<HeroView>().FromInstance(heroView);
            Container.BindInterfacesAndSelfTo<HeroWeaponController>().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroController>().AsSingle().NonLazy();
        }
    }
}
