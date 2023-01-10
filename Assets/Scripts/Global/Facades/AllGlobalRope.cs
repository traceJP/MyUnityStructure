using Global.Entities.Impl;
using UnityEngine;

namespace Global.Facades
{
    public static class AllGlobalRope
    {
        
        public static InputEntity InputEntity { get; private set; }

        public static PlayerEntity PlayerEntity { get; private set; }
        
        
        public static void Ctor()
        {
            
            InputEntity = new InputEntity();
            Debug.Log("InputEntity 生成");

            PlayerEntity = new PlayerEntity();
            Debug.Log("PlayerEntity 生成");
            
        }
        
        
    }
}