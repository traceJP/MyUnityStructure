using Role;
using UIRenderer;

namespace Facades
{
    public static class AllManager
    {
        
        
        public static UIManager UIManager;

        
        
        public static RoleManager RoleManager;

        // Ctor 个人的规定写法 意义：静态类的初始化Init方法 完整名为 Construction
        public static void Ctor()
        {
            UIManager = null;
            RoleManager = null;
        }


    }
}