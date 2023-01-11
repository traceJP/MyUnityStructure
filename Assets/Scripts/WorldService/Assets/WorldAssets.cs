using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace WorldService.Assets
{
    public class WorldAssets
    {
        
        /// <summary>
        /// 角色资源
        /// </summary>
        private const string RoleAssetsTag = "RoleAssets";
        public Dictionary<RoleAssetsEnum, GameObject> RoleAssets { get; private set; }
        public enum RoleAssetsEnum
        {
            RoleEntity,
        }

        public WorldAssets()
        {
            RoleAssets = new Dictionary<RoleAssetsEnum, GameObject>();
        }

        public async Task LoadAllAssets()
        {
            await AddressableUtil.LoadWithLabel<GameObject>(RoleAssetsTag, res =>
            {
                var enumKey = Enum.Parse<RoleAssetsEnum>(res.name);
                RoleAssets.Add(enumKey, res);
            });
        }
        
     
    }
}