using UnityEngine;

namespace Facades
{
    public class AllGlobalRope
    {
        
        // 主相机
        public static Camera MainCamera { get; private set; }
        public static Camera SetMainCamera(Camera mainCamera) => MainCamera = mainCamera;

        
        public static void Ctor()
        {
            MainCamera = null;
        }
        
    }
}