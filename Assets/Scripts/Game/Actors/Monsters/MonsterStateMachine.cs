using JetBrains.Annotations;
using Zenject;

namespace Game.Actors.Monsters
{
    [UsedImplicitly]
    public class MonsterStateMachine : ITickable
    {
        [Inject] private readonly IFactory<MonsterState, IMonsterState> statesFactory;

        private IMonsterState currentState;

        [Inject]
        private void Init()
        {
            GoToState(MonsterState.WalkTowardsHeroAndWaitForCooldown);
        }

        public void GoToState(MonsterState state)
        {
            currentState = statesFactory.Create(state);
        }

        public void Tick()
        {
            currentState.Update();
        }
    }
}
