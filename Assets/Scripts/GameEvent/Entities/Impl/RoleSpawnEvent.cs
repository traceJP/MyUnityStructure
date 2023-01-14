using UnityEngine;

namespace GameEvent.Entities.Impl
{
    public class RoleSpawnEvent : IGameEvent
    {
        public Vector3 SpawnPoint { get; private set; }
        public Vector3 SetSpawnPoint(Vector3 spawnPoint) => SpawnPoint = spawnPoint;
        
    }
}