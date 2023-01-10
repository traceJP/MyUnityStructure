namespace Global.Entities.Event
{

    public class StartGameEvent
    {
        
        public bool IsTrigger { get; private set; }

        public void SetIsTrigger(bool isTrigger) => IsTrigger = isTrigger;
        
    }
}