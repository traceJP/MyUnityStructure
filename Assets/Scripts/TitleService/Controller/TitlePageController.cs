using GameEvent.Entities.Impl;
using GameEvent.Facades;
using Global.Enums;
using Global.Facades;
using UIRenderer.Entities;
using UIRenderer.Facades;

namespace TitleService.Controller
{
    public class TitlePageController
    {
        public void Ctor() { }


        public void Init()
        {
            AllManager.EventManager.AddListener<StartGameEvent>(OnStartGameHandle);
        }

        private void OnStartGameHandle(StartGameEvent startGameEvent)
        {
            var titlePage = AllManager.UIManager.OpenPage<UIPageTitle>();
            titlePage.Init();
            titlePage.OnStartGameButton += OnStartGameButton;
            AllUIRendererRope.SetUIPanels(titlePage);
        }

        private void OnStartGameButton()
        {
            // 关闭标题页
            AllUIRendererRope.GetUIPanels<UIPageTitle>().TearDown();
            
            // 播放背景音乐
            AllManager.AudioManager.PlayMusic(MusicEnum.GoForIt, AudioGroupEnum.Master);
            
            // 生成世界
            AllManager.EventManager.Broadcast(EventRope.WorldSpawnEvent);
        }
        
    }
}