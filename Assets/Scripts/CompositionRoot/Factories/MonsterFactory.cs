using Game;
using Game.Actors;
using Game.Actors.Monsters;
using Game.PlayingField;
using JetBrains.Annotations;
using Zenject;

namespace CompositionRoot.Factories
{
    [UsedImplicitly]
    public class MonsterFactory : IFactory<MonsterVisualConfig, MonsterView>
    {
        [Inject] private readonly DiContainer diContainer;
        [Inject] private readonly PlayingFieldController playingFieldController;
        
        public MonsterView Create(MonsterVisualConfig visualConfig)
        {
            var result =
                diContainer.InstantiatePrefabForComponent<MonsterView>(visualConfig.ViewPrefab);
            playingFieldController.PlaceInRandomPlace(result);
            return result;
        }
    }
}
