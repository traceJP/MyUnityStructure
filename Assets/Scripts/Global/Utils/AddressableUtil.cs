using System;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Utils
{
    public static class AddressableUtil
    {
        
        public static async Task LoadWithLabel<T>(string label, Action<T> callback) {
            try {
                var labelReference = new AssetLabelReference
                {
                    labelString = label
                };
                var list = await Addressables.LoadAssetsAsync<T>(labelReference, null).Task;
                foreach (var res in list)
                {
                    callback(res);
                }
            } catch {
                throw new Exception("Failed to load assets with label: " + label);
            }
        }

        public static async Task LoadWithName<T>(string name, Action<T> callback)
        {
            try {
                var res = await Addressables.LoadAssetAsync<T>(name).Task;
                callback(res);
            } catch {
                throw new Exception("Failed to load assets with name: " + name);
            }
        }
        
        
    }
}