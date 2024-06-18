using Game.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private Image weaponIconImage;
        
        public void ShowWeapon(WeaponConfig weapon)
        {
            weaponIconImage.sprite = weapon.Icon;
        }
    }
}
