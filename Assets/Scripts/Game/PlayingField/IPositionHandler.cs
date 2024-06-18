using UnityEngine;

namespace Game.PlayingField
{
    public interface IPositionHandler
    {
        Vector3 WorldPosition { get; }
        void SetPosition(Vector3 position);
    }
}
