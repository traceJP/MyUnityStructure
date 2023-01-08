using System.Collections.Generic;
using UnityEngine;
using Utils.Base;

namespace WorldService.Assets
{
    public class WorldAssets : BaseAssetsUtil
    {
        private Dictionary<string, GameObject> _allPrefab;

        public WorldAssets()
        {
            _allPrefab = new Dictionary<string, GameObject>();
        }
        
        // TODO: 封装Assets的基本逻辑 例如，拿取一个预制体，拿取一段音频等操作
        
        
    }
}