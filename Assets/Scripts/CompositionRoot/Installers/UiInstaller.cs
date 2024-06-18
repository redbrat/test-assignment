using Game.UI;
using UnityEngine;
using Zenject;

namespace CompositionRoot.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private WeaponUI weaponUI;
        [SerializeField] private SelectedMonsterUI selectedMonsterUI;
        [SerializeField] private HealthUI healthUI;

        public override void InstallBindings()
        {
            Container.BindInstance(weaponUI);
            Container.BindInstance(selectedMonsterUI);
            Container.BindInstance(healthUI);
        }
    }
}
