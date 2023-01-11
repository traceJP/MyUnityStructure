using GameEvent.Entities.Impl;

namespace GameEvent.Facades
{
    public static class EventRope
    {
        
        public static StartGameEvent StartGameEvent { get; private set; }
        public static void SetStartGameEvent(StartGameEvent ev) => StartGameEvent = ev;

        
        public static void Ctor()
        {
            StartGameEvent = new StartGameEvent();
        }
        
    }
    
}