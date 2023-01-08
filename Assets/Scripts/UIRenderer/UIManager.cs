using UIRenderer.Entities;
using UnityEngine;

namespace UIRenderer
{
    
    /// <summary>
    ///  UI管理器
    /// 
    /// </summary>
    public class UIManager    // 不需要拖拽绑定后 也不需要继承 MonoBehaviour 了
    {
        
        // 引入了 AA包 之后 即可在游戏时加载所有资源 不要再使用拖拽绑定
        private Canvas _canvas;
        private UIPageLogin _uiPageLoginPrefab;


        public void Inject(Canvas canvas)
        {
            this._canvas = canvas;
            
        }

        public void Init(UIPageLogin uiPageLogin)
        {
            this._uiPageLoginPrefab = uiPageLogin;
        }

        public UIPageLogin OpenLogin()
        {
            UIPageLogin page = GameObject.Instantiate(_uiPageLoginPrefab, _canvas.transform);
            return page;
        }

        
        
        
    }
    

    
    
}