using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.PlayingField
{
    [UsedImplicitly]
    public class PlayingFieldController
    {
        [Inject] private readonly GameConfig gameConfig; 
            
        public void PlaceInRandomPlace(IPositionHandler result)
        {
            result.SetPosition(new Vector3(Random.Range(0, gameConfig.PlayingFieldExtents.x), 0,
                Random.Range(0, gameConfig.PlayingFieldExtents.y)));
        }
    }
}
