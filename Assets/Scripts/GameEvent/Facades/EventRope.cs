using GameEvent.Entities.Impl;

namespace GameEvent.Facades
{
    public static class EventRope
    {
        
        public static StartGameEvent StartGameEvent { get; private set; }

        public static RoleSpawnEvent RoleSpawnEvent { get; private set; }


        public static void Ctor()
        {
            StartGameEvent = new StartGameEvent();
            RoleSpawnEvent = new RoleSpawnEvent();
        }
        
    }
    
}