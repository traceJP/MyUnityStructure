using WorldService.Entities;

namespace WorldService.Facades
{
    public static class AllWorldRope
    {
        
        public static RoleEntity RoleEntity { get; private set; }
        public static void SetRoleEntity(RoleEntity roleEntity) => RoleEntity = roleEntity;


        public static void Ctor()
        {
            RoleEntity = null;
        }
        
        
    }
}