using Facades;
using GameEvent.Entities.Impl;
using Global.Enums;
using UIRenderer.Entities;

namespace TitleService.Controller
{
    public class TitlePageController
    {
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
            AllManager.EventManager.Broadcast(AllEventRope.WorldSpawnEvent);
        }
        
    }
}