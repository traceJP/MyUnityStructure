using UnityEngine;

namespace WorldService.Entities
{
    
    [RequireComponent(typeof(CharacterController))]
    public class RoleEntity : MonoBehaviour
    {

        public float moveSpeed = 5F;

        public float rotationSmoothTime;

        public Transform standThirdPersonCameraRoot;
        
        private CharacterController _character;

        private MeshRenderer _mesh;

        private Animator _anim;
        private static readonly int Speed = Animator.StringToHash("Speed");
        

        public void Awake()
        {

            _character = GetComponent<CharacterController>();
            _mesh = transform.GetChild(0).GetComponentInChildren<MeshRenderer>();
            _anim = transform.GetChild(0).GetComponentInChildren<Animator>();
            standThirdPersonCameraRoot = transform.GetChild(1);
            
            Debug.Assert(_character != null);
            Debug.Assert(_mesh != null);
            Debug.Assert(_anim != null);
            Debug.Assert(standThirdPersonCameraRoot != null);
            
            Debug.Log("角色已生成！");
            
        }
        
        
        public void Move(Vector2 moveAxis, Transform cameraTransform)
        {
            var targetSpeed = moveSpeed;
            var targetRotation = 0F;
            
            // 角色朝向
            if (moveAxis != Vector2.zero)
            {
                targetRotation = Mathf.Atan2(moveAxis.x, moveAxis.y) * Mathf.Rad2Deg +
                                  cameraTransform.eulerAngles.y;
                var rotationVelocity = 0F;
                var rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                    ref rotationVelocity, rotationSmoothTime);
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            var targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
            
            // 移动角色
            if (moveAxis == Vector2.zero)
            {
                targetSpeed = 0;
            }
            _character.SimpleMove(targetDirection.normalized * targetSpeed);
            
            // 动画切换
            SwitchAnimation(moveAxis);
        }

        private void SwitchAnimation(Vector2 moveAxis)
        {
            _anim.SetFloat(Speed, moveAxis.magnitude * moveSpeed);
        }

    }
}