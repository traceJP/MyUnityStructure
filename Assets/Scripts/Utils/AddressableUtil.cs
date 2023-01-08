﻿using System;
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
                for (var i = 0; i < list.Count; i += 1) {
                    var res = list[i];
                    callback(res);
                }
            } catch {
                throw new Exception("Failed to load assets with label: " + label);
            }
        }
        
        
    }
}