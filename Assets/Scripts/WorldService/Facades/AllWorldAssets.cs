using UnityEngine;
using WorldService.Assets;

namespace WorldService.Facades
{
    public static class AllWorldAssets
    {
        
        public static WorldAssets WorldAssets { get; private set; }

        public static void Ctor()
        {
            WorldAssets = new WorldAssets();
            Debug.Log("世界资源实体 生成");
        }
        
    }
}