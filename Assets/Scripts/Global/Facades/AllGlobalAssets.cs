using Global.Assets;
using UnityEngine;

namespace Global.Facades
{
    public static class AllGlobalAssets
    {
        
        public static GlobalAssets GlobalAssets { get; private set; }

        public static void Ctor()
        {
            GlobalAssets = new GlobalAssets();
            Debug.Log("全局资源实体 生成");
        }
        
    }
}