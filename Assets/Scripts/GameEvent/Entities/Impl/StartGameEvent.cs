namespace GameEvent.Entities.Impl
{

    public class StartGameEvent : IGameEvent
    {
        
        public bool IsTrigger { get; private set; }

        public void SetIsTrigger(bool isTrigger) => IsTrigger = isTrigger;
        
    }
}