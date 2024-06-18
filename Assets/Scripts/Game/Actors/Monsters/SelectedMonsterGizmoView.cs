using UnityEngine;
using Zenject;

namespace Game.Actors.Monsters
{
    public class SelectedMonsterGizmoView : MonoBehaviour, ITickable
    {
        [SerializeField] private GameObject visuals;
        
        private MonsterView currentMonster;
        
        [Inject]
        private void Init(SelectedMonsterController selectedMonsterController)
        {
            selectedMonsterController.MonsterSelected += OnMonsterSelected;
            OnMonsterSelected(selectedMonsterController.SelectedMonster);
        }

        private void OnMonsterSelected(MonsterView monster)
        {
            currentMonster = monster;
            visuals.SetActive(monster != null);
            Tick();
        }

        public void Tick()
        {
            if (currentMonster == null)
            {
                return;
            }
            transform.position = currentMonster.WorldPosition;
        }
    }
}
