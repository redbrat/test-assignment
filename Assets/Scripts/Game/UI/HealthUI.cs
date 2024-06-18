using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthValueText;
        [SerializeField] private Scrollbar healthBar;

        public void SetHealth(float value, float maxHealth)
        {
            healthValueText.text = ((int)value).ToString();
            healthBar.size = value / maxHealth;
        }
    }
}
