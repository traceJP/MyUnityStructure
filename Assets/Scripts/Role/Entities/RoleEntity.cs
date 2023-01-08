using UnityEngine;

// 这里是Models层
// 所以这里是不允许知道上层的命名空间
// 例如这里不允许使用 using AllManagers ，不允许使用 using Manager等引入上层命名空间的操作
namespace Role.Entities
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