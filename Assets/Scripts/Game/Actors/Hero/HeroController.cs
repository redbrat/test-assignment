using Game.Actors.Monsters;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Actors.Hero
{
    [UsedImplicitly]
    public class HeroController : ITickable
    {
        [Inject] private readonly HeroConfig config;
        [Inject] private readonly HeroView view;
        [Inject] private readonly HeroWeaponController heroWeaponController;
        [Inject] private readonly SelectedMonsterController selectedMonsterController;
        
        public void Tick()
        {
            var translation = Input.GetAxis("Vertical") * config.MovementSpeed * Time.deltaTime;
            var rotation = Input.GetAxis("Horizontal") * config.RotationSpeed * Time.deltaTime;
            view.MoveForward(translation);
            view.Rotate(rotation);

            if (Input.GetKeyUp(KeyCode.Q))
            {
                heroWeaponController.CycleWeapons(1);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                heroWeaponController.CycleWeapons(-1);
            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                selectedMonsterController.CycleThroughMonsters(Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            }

            if (Input.GetKey(KeyCode.X))
            {
                heroWeaponController.Shoot();
            }
        }
    }
}
