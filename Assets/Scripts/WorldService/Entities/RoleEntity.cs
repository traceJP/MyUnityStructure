using UnityEngine;

namespace WorldService.Entities
{
    
    [RequireComponent(typeof(CharacterController))]
    public class RoleEntity : MonoBehaviour
    {

        public float moveSpeed = 5F;

        public Transform standThirdPersonCameraRoot;
        
        private CharacterController _character;

        private MeshRenderer _mesh;
        

        public void Awake()
        {

            _character = GetComponent<CharacterController>();
            _mesh = transform.GetChild(0).GetComponentInChildren<MeshRenderer>();
            standThirdPersonCameraRoot = transform.GetChild(1);
            
            Debug.Assert(_character != null);
            Debug.Assert(_mesh != null);
            Debug.Assert(standThirdPersonCameraRoot != null);
            
            Debug.Log("角色已生成！");
            
        }
        
        
        public void Move(Vector2 moveAxis, Transform cameraTransform) {
            var y = _character.velocity.y;
            var moveDir = cameraTransform.forward * moveAxis.y + cameraTransform.right * moveAxis.x;
            moveDir.Normalize();
            _character.SimpleMove(moveDir * moveSpeed);
            var velocity = _character.velocity;
            velocity.y = y;
            _character.SimpleMove(velocity);
        }

    }
}