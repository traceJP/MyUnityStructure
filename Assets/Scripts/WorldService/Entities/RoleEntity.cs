using UnityEngine;

namespace WorldService.Entities
{
    public class RoleEntity : MonoBehaviour
    {


        public void Init()
        {
            Debug.Log("角色已生成！");
        }
        
        
        public void Move()
        {
            transform.position += Vector3.right * (Time.deltaTime * -20);
        }
        
        
        
    }
}