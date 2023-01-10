using System.Threading.Tasks;
using Facades;
using Global.Facades;
using UIRenderer.Entities;
using UnityEngine;

namespace Global.Controller
{
    public class MainController
    {

        public void Ctor()
        {
            
        }

        public void Inject(Canvas canvas)
        {
            AllManager.UIManager.Inject(canvas);
        }
        
        public async Task Init()
        {
            // 加载全局资源
            await AllGlobalAssets.GlobalAssets.LoadAllAssets();

            // 管理器 Init
            await AllManager.UIManager.Init();


            // ============================================= 开始游戏 ==================================================
            var titlePage = AllManager.UIManager.OpenPage<UIPageLogin>();
            titlePage.OnStartGameHandle += OnStartGameHandle;
            titlePage.Init();
            
        }

        public void Tick()
        {

        }

        /// <summary>
        /// 开始游戏后做的业务逻辑
        /// </summary>
        private void OnStartGameHandle()
        {
            Debug.Log("开始游戏");
            var ev = AllGlobalEventCenter.StartGameEvent;
            ev.SetIsTrigger(true);
        }

        
    }
}