using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIRenderer.Enums;
using UnityEngine;
using Utils;

namespace UIRenderer.Assets
{
    public class UIAssets
    {

        private readonly Dictionary<UITypeID, GameObject> _all;
        private readonly Dictionary<Type, GameObject> _allInType;

        public UIAssets()
        {
            _all = new Dictionary<UITypeID, GameObject>();
            _allInType = new Dictionary<Type, GameObject>();
        }
        
        public async Task LoadAll() {
            const string label = "UIAssets";
            await AddressableUtil.LoadWithLabel<GameObject>(label, go => {
                var panel = go.GetComponent<IUIPanel>();
                Debug.Assert(panel != null);
                _all.Add(panel.TypeID, go);
                _allInType.Add(panel.GetType(), go);
            });
        }

        public GameObject GetUIPrefab(UITypeID uuid) {
            _all.TryGetValue(uuid, out var go);
            Debug.Assert(go != null);
            return go;
        }

        public GameObject GetUIPrefab(Type type) {
            _allInType.TryGetValue(type, out var go);
            Debug.Assert(go != null);
            return go;
        }
        
    }
}