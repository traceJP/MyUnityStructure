using System.Threading.Tasks;
using DG.Tweening;
using UIRenderer.Assets;
using UnityEngine;
using UnityEngine.UI;

namespace UIRenderer
{
    public class UIManager
    {

        private Canvas _canvas;

        private UIAssets _layoutAssets;

        private Image _backGround;

        private Transform _pageRoot, _windowRoot, _worldTipsRoot, _uiTipsRoot;
        
        public void Inject(Canvas canvas)
        {
            _canvas = canvas;
        }

        public async Task Init()
        {
            // 加载资源
            _layoutAssets = new UIAssets();
            await _layoutAssets.LoadAll();
            
            // 初始化 canvas层级
            var trans = _canvas.transform;
            _backGround = trans.GetChild(0).GetComponent<Image>();
            _worldTipsRoot = trans.GetChild(1);
            _pageRoot = trans.GetChild(2);
            _windowRoot = trans.GetChild(3);
            _uiTipsRoot = trans.GetChild(4);

            Debug.Assert(_backGround != null);
            Debug.Assert(_worldTipsRoot != null);
            Debug.Assert(_pageRoot != null);
            Debug.Assert(_windowRoot != null);
            Debug.Assert(_uiTipsRoot != null);
            
        }

        private GameObject GetPrefab<T>() {
            return _layoutAssets.GetUIPrefab(typeof(T));
        }

        public T OpenPage<T>() where T : IUIPanel {
            var prefab = GetPrefab<T>();
            prefab = Object.Instantiate(prefab, _pageRoot);
            SetFadeOut();
            return prefab.GetComponent<T>();
        }

        public GameObject SetFadeIn()
        {
            _backGround.color = Color.black;
            return _backGround.gameObject;
        }

        public GameObject SetFadeOut()
        {
            _backGround.color = Color.clear;
            return _backGround.gameObject;
        }
        
    }
    
}