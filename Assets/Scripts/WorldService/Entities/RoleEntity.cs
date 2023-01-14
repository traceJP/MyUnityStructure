using UnityEngine;
using WorldService.Entities.Component.FSM;
using WorldService.Entities.Component.FSM.Role;

namespace WorldService.Entities
{
    public class RoleEntity : MonoBehaviour
    {

        private FSMComponent<RoleStateEnum> _fsm;

        public void Awake()
        {
            _fsm = new FSMComponent<RoleStateEnum>();
            var idle = new IdleState();
            idle.Inject(gameObject.GetComponent<Animator>());
            _fsm.AddState(RoleStateEnum.Idle, idle);

            Debug.Log("角色已生成！");
        }
        
        
        public void Move()
        {
            transform.position += Vector3.right * (Time.deltaTime * -20);
        }
        
        
        
    }
}