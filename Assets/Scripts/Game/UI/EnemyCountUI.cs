using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class EnemyCountUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI monstersCountText;
        
        [Inject]
        private void Init(GameManager gameManager)
        {
            gameManager.MonstersCountChanged += OnMonstersCountChanged;
            OnMonstersCountChanged(gameManager.MonstersCount);
        }

        private void OnMonstersCountChanged(int newCount)
        {
            monstersCountText.text = $"Enemy count: {newCount}";
        }
    }
}
