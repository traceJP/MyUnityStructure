using Role.Entities;
using UIRenderer.Entities;

namespace Facades
{
    
    /// <summary>
    /// 缓存的所有字段都需要去添加 getter / setter 方法
    ///
    /// 如果里面缓存多了，则需要再次进行区分，将ALlRepository 拆成 MapRepository， RoleRepository等
    /// </summary>
    public static class AllRepository
    {

        public static UIPageLogin uIPageLogin;
        


        public static RoleEntity roleEntity;


        public static void Ctor()
        {
            uIPageLogin = null;
            roleEntity = null;
        }


    }
}