using UnityEngine;

namespace WorldService.Entities
{
    
    //[RequireComponent(typeof(CharacterController))]
    public class RoleEntity : MonoBehaviour
    {

        public float moveSpeed = 5F;

        //private CharacterController _character;
        private Rigidbody _rigidbody;

        public void Awake()
        {

            _rigidbody = GetComponent<Rigidbody>();
            
            Debug.Log("角色已生成！");
            
        }
        
        
        public void Move(Vector2 moveAxis, Transform cameraTransform) {
            float y = _rigidbody.velocity.y;

            var moveDir = cameraTransform.forward * moveAxis.y + cameraTransform.right * moveAxis.x;
            moveDir.Normalize();

            _rigidbody.velocity = moveDir * moveSpeed;
            var velo = _rigidbody.velocity;
            velo.y = y;
            _rigidbody.velocity = velo;

        }
        
        
        
    }
}