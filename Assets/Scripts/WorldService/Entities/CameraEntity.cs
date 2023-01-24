using Cinemachine;
using UnityEngine;

namespace WorldService.Entities
{

    public class CameraEntity : MonoBehaviour
    {
        
        // 镜头灵敏度
        public float lensSensitivity = 5F;

        // 最大 | 最小 爬升距离
        public float topClamp = 70;
        public float bottomClamp = -30;
        
        // 最大 | 最小 视距
        public float maxClampDistance = 10;
        public float minClampDistance = 5;

        // 是否反转 Axis Y
        public bool isRevertY;
        

        // Rotate Horizontal
        private float _cinemachineTargetYaw;
        // Rotate Vertical
        private float _cinemachineTargetPitch;

        
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

        public void Rotate(Vector2 axis)
        {
            axis.y = isRevertY ? axis.y : -axis.y;
            
            _cinemachineTargetYaw += axis.x * lensSensitivity;
            _cinemachineTargetPitch += axis.y * lensSensitivity;
            
            // 角度限制
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, bottomClamp, topClamp);

            // 旋转
            transform.rotation = Quaternion.Euler(0, _cinemachineTargetYaw, 0);
            _cm.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0, 0);

        }

        public void PullDistance(float distanceOffset)
        {
            var targetDistance = _transposer.m_CameraDistance + distanceOffset;
            if (targetDistance > maxClampDistance || targetDistance < minClampDistance)
            {
                return;
            }
            _transposer.m_CameraDistance += distanceOffset;
        }
        
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360F) lfAngle += 360F;
            if (lfAngle > 360F) lfAngle -= 360F;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

    }
}