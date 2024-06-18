using Game.Actors.Monsters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class SelectedMonsterUI : MonoBehaviour
    {
        [SerializeField] private Image monsterIconImage;

        [Inject] private SelectedMonsterController selectedMonsterController;

        [Inject]
        private void Init()
        {
            selectedMonsterController.MonsterSelected += OnMonsterSelected;
            OnMonsterSelected(selectedMonsterController.SelectedMonster);
        }

        private void OnMonsterSelected(MonsterView monsterView)
        {
            monsterIconImage.enabled = monsterView != null;
            if (monsterView == null)
            {
                return;
            }
            var visualConfig = selectedMonsterController.GetVisualConfigForMonster(monsterView);
            if (visualConfig == null)
            {
                return;
            }
            monsterIconImage.sprite = visualConfig.Icon;
        }
    }
}
