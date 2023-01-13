using UnityEngine;

namespace WorldService.Entities
{
    public class WorldEntity : MonoBehaviour
    {

        public Transform SpawnerGroup { get; private set; }

        public Transform CameraGroup { get; private set; }

        private void Awake() {
            
            // ==== GROUP ====
            SpawnerGroup = transform.Find("SPAWNER_GROUP");
            CameraGroup = transform.Find("CAMERA_GROUP");

            Debug.Assert(SpawnerGroup != null);
            Debug.Assert(CameraGroup != null);

        }
        
        
    }
}