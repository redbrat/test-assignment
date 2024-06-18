using Game.PlayingField;

namespace Game.Actors
{
    public interface IAttackable : IPositionHandler
    {
        public bool IsDestroyed { get; }
        public void ReceiveDamage(float amount);
    }
}
