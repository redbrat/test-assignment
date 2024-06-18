using Game;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private MonstersConfig monstersConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(gameConfig);
            Container.BindInstance(monstersConfig);
        }
    }
}
