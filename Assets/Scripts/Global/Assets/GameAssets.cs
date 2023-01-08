using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Utils;

namespace Assets
{
    public class GameAssets
    {

        public Dictionary<string, GameObject> UIAssets;
        public Dictionary<string, GameObject> RoleAssets;

        public GameAssets()
        {
            UIAssets = new Dictionary<string, GameObject>();
            RoleAssets = new Dictionary<string, GameObject>();
        }

        public async Task LoadAllAssets()
        {
            await AddressableUtil.LoadWithLabel<GameObject>("UIAssets", res =>
            {
                UIAssets.Add(res.name, res);
            });
            await AddressableUtil.LoadWithLabel<GameObject>("RoleAssets", res =>
            {
                RoleAssets.Add(res.name, res);
            });
        }
        
        // ============================ GET =============================================
        // TODO；这里需要封装一下
        public GameObject GETUIPageLogin()
        {
            if (UIAssets.TryGetValue("UIPageLogin", out GameObject go))
            {
                return go;
            }
            return null;
        }
        public GameObject GetRolePrefab()
        {
            if (RoleAssets.TryGetValue("RoleEntity", out GameObject go))
            {
                return go;
            }
            return null;
        }
        
        







    }
}