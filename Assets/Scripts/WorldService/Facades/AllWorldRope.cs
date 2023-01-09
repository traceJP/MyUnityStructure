using Role.Entities;
using WorldService.Assets;

namespace WorldService.Facades
{
    public static class AllWorldRope
    {
        
        public static WorldAssets WorldAssets;
        
        public static RoleEntity roleEntity;


        public static void Ctor()
        {
            WorldAssets = new WorldAssets();
            roleEntity = null;
        }
        
        
    }
}