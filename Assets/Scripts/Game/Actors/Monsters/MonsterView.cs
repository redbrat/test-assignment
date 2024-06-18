using UnityEngine;
using Zenject;

namespace Game.Actors.Monsters
{
    public class MonsterView : MonoBehaviour, IAttackable
    {
        public bool IsDestroyed => health <= 0;
        public Vector3 WorldPosition => transform.position;

        [Inject] private readonly MonsterConfig config;
        [Inject] private readonly SelectedMonsterController selectedMonsterController;
        [Inject] private readonly GameManager gameManager;

        private float health;

        [Inject]
        private void Init()
        {
            health = config.Health;
        }
        
        public void ReceiveDamage(float amount)
        {
            health -= amount * config.Defense;
            if (health <= 0)
            {
                Destroy(gameObject);
                gameManager.MonsterHasBeenKilled();
                selectedMonsterController.UnregisterMonster(this);
            }
        }
        
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
