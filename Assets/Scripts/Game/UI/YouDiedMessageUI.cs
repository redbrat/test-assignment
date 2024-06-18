using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class YouDiedMessageUI : MonoBehaviour
    {
        [SerializeField] private GameObject visual;

        [Inject]
        private void Init(GameManager gameManager)
        {
            gameManager.GameEnd += OnGameEnd;
        }

        private void OnGameEnd()
        {
            visual.SetActive(true);
        }
    }
}
