using GameEvent.Entities.Impl;

namespace Facades
{
    public static class AllEventRope
    {
        
        public static StartGameEvent StartGameEvent { get; private set; }
        
        public static WorldSpawnEvent WorldSpawnEvent { get; private set; }

        public static RoleSpawnEvent RoleSpawnEvent { get; private set; }


        public static void Ctor()
        {
            StartGameEvent = new StartGameEvent();
            RoleSpawnEvent = new RoleSpawnEvent();
            WorldSpawnEvent = new WorldSpawnEvent();
        }
        
    }
    
}