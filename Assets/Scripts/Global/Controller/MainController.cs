using System.Threading.Tasks;
using Facades;
using Global.Enums;
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

        public void Inject(Canvas canvas, AudioSource globalSource)
        {
            AllManager.UIManager.Inject(canvas);
            AllManager.AudioManager.Inject(globalSource);
        }
        
        public async Task Init()
        {
            // 加载全局资源
            // await AllGlobalAssets.GlobalAssets.LoadAllAssets();

            // 管理器 Init
            await AllManager.UIManager.Init();
            await AllManager.AudioManager.Init();


            // ============================================= 开始游戏 ==================================================
            var titlePage = AllManager.UIManager.OpenPage<UIPageTitle>();
            titlePage.OnStartGameHandle += OnStartGameHandle;
            titlePage.Init();
            _uiPageTitle = titlePage;
        }

        public void Tick()
        {

        }

        
        // TODO: 临时标题页缓存 所有业务需要从MainController 移动到 TitleService.TitlePageController 中
        private UIPageTitle _uiPageTitle;
        private void OnStartGameHandle()
        {
            Debug.Log("开始游戏");
            var ev = AllGlobalEventCenter.StartGameEvent;
            // 关闭标题页
            _uiPageTitle.TearDown();
            
            // 播放背景音乐
            AllManager.AudioManager.PlayMusic(MusicEnum.GoForIt, AudioGroupEnum.Master);
            
            ev.SetIsTrigger(true);
        }

        
    }
}