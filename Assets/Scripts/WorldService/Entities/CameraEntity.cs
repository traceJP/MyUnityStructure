using Cinemachine;
using UnityEngine;

namespace WorldService.Entities
{

    public class CameraEntity : MonoBehaviour
    {
        
        public float sensitivity = 5F;
        
        public bool isRevertY;

        
        private CinemachineVirtualCamera _cm;
        
        private CinemachineFramingTransposer _transposer;
 
        private void Awake() {
            
            _cm = GetComponentInChildren<CinemachineVirtualCamera>();
            _transposer = _cm.GetCinemachineComponent<CinemachineFramingTransposer>();

            Debug.Assert(_cm != null);

        }

        public void Follow(Transform target) {
            _cm.Follow = target;
        }

        public void RotateHorizontal(float horizontalAxis) {
            var euler = new Vector3(0, horizontalAxis * sensitivity, 0);
            transform.Rotate(euler);
        }

        public void RotateVertical(float verticalAxis) {
            verticalAxis = isRevertY ? -verticalAxis : verticalAxis;
            var euler = new Vector3(verticalAxis * sensitivity, 0, 0);
            _cm.transform.Rotate(euler);
        }

        public void PullDistance(float distanceOffset) {
            _transposer.m_CameraDistance += distanceOffset;
        }

    }
}