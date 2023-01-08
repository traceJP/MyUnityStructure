using System.Threading.Tasks;
using Assets;
using UnityEngine;
using Facades;
using Models;
using Role.Entities;
using UIRenderer.Entities;

namespace Controller
{
    public class MainController
    {
                
        public MainController()
        {
            
        }

        public void Ctor()
        {
            
        }

        public void Inject(Canvas canvas)
        {
            AllManager.UIManager.Inject(canvas);
        }
        
        public async Task Init()
        {
            // 初始化加载资源
            GameAssets gameAssets = AllAssets.GameAssets;
            await AllAssets.GameAssets.LoadAllAssets();

            // 初始化 uiManager 首先要初始化manager中的所有页面 所以 得到 UIPageLogin 上的脚本 用于初始化 uiManager
            UIPageLogin prefab = gameAssets.GETUIPageLogin().GetComponent<UIPageLogin>();
            AllManager.UIManager.Init(prefab);

            RoleEntity rolePrefab = gameAssets.GetRolePrefab().GetComponent<RoleEntity>();
            AllManager.RoleManager.Init(rolePrefab);
            
            // 业务逻辑1
            // 通过 AllManager 拿到管理器的缓存
            UIPageLogin page = AllManager.UIManager.OpenLogin();    // 打开Login页面，并且缓存到变量中
            page.OnStartGameHandle += OnStartGame;
            page.Init();
            // 将UIPageLogin缓存到统一管理缓存的脚本文件夹中
            AllRepository.uIPageLogin = page;
        }

        public void Tick()
        {
            // 第二个要求生成角色的入口
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                // 通知 RoleController 生成角色
                StartGameEvent ev = AllEventCenter.StartGameEvent;
                ev.Chapter = 1;
                ev.Level = 1;
                ev.SetIsTrigger(true);
            }
        }

        public void FixedTick()
        {
            
        }
        
        /// <summary>
        /// 开始游戏后做的业务逻辑2
        /// </summary>
        void OnStartGame()
        {
            Debug.Log("开始游戏");
        
            GameObject.Destroy(AllRepository.uIPageLogin.gameObject);
        
            // 生成角色的代码不能写在这里 因为 很多业务都可以生成一个角色，所以生成角色 是 RoleController 的业务
            // 此处只需要通知其他业务开始游戏了即可
            // 即这里 通过事件中心 触发了事件 向 RoleController 中进行了一次通信 要求 RoleController 进行生成角色
            StartGameEvent ev = AllEventCenter.StartGameEvent;
            ev.Chapter = 1;
            ev.Level = 1;
            ev.SetIsTrigger(true);
        }

        
    }
}