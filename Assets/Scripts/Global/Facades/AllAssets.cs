using System;
using Assets;

namespace Facades
{
    public static class AllAssets
    {

        public static GameAssets GameAssets;
        
        
        public static void Ctor()
        {
            GameAssets = new GameAssets();
            
        }

    }
}