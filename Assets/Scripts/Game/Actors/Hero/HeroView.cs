using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Actors.Hero
{
    public class HeroView : MonoBehaviour, IAttackable
    {
        public bool IsDestroyed => health <= 0;
        public Vector3 WorldPosition => transform.position;

        [Inject] private readonly HeroConfig heroConfig;
        [Inject] private readonly GameManager gameManager;
        [Inject] private readonly HealthUI healthUI;

        private float health;
        
        [Inject]
        private void Init()
        {
            health = heroConfig.Health;
            healthUI.SetHealth(health, health);
        }
        
        public void ReceiveDamage(float amount)
        {
            health -= amount * heroConfig.Defense;
            if (health <= 0)
            {
                gameManager.HeroIsDead();
            }
            healthUI.SetHealth(health, heroConfig.Health);
        }
        
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void MoveForward(float translation)
        {
            transform.Translate(0, 0, translation);
        }

        public void Rotate(float rotation)
        {
            transform.Rotate(0, rotation, 0);
        }
    }
}
