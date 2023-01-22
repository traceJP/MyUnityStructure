using WorldService.Entities;

namespace WorldService.Facades
{
    public static class AllWorldRope
    {
        
        public static RoleEntity RoleEntity { get; private set; }
        public static void SetRoleEntity(RoleEntity roleEntity) => RoleEntity = roleEntity;
        
        public static WorldEntity WorldEntity { get; private set; }
        public static void SetWorldEntity(WorldEntity worldEntity) => WorldEntity = worldEntity;
        
        public static CameraEntity RoleCamera { get; private set; }
        public static void SetRoleCamera(CameraEntity cameraEntity) => RoleCamera = cameraEntity;


        public static void Ctor()
        {
            RoleEntity = null;
            WorldEntity = null;
            RoleCamera = null;
        }
        
    }
}