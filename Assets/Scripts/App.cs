using System;
using Audio;
using GameEvent;
using GameEvent.Facades;
using Global.Controller;
using Global.Facades;
using TitleService.Controller;
using UIRenderer;
using UIRenderer.Facades;
using UnityEngine;
using WorldService.Controller;
using WorldService.Facades;

public class App : MonoBehaviour
{

    private bool _isInit;
    
    // 主业务
    private MainController _mainController;
    
    // 世界业务
    private WorldController _worldController;
    
    // 角色业务
    private RoleController _roleController;
    
    // 标题业务
    private TitlePageController _titlePageController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _isInit = false;
        
        // ================================================== CTOR ====================================================
        AllManager.Ctor();

        AllGlobalRope.Ctor();
        AllWorldRope.Ctor();
        AllUIRendererRope.Ctor();
        EventRope.Ctor();

        AllWorldAssets.Ctor();

        _mainController = new MainController();
        _mainController.Ctor();
        _worldController = new WorldController();
        _worldController.Ctor();
        _roleController = new RoleController();
        _roleController.Ctor();
        _titlePageController = new TitlePageController();
        _titlePageController.Ctor();
        
        
        // ======================================= INJECT =============================================================
        AllManager.SetUIManager(new UIManager());
        AllManager.SetAudioManager(new AudioManager());
        AllManager.SetEventManager(new EventManager());
        _mainController.Inject(
            transform.GetComponentInChildren<Canvas>(),
            transform.GetComponentInChildren<AudioSource>()
            );

        
        // ================================================= INIT =====================================================
        Action action = async () =>
        {
            await _mainController.Init();
            await _worldController.Init();
            _roleController.Init();
            _titlePageController.Init();
            _isInit = true;
            GameStartController();
        };
        action.Invoke();
      
    }
    
    private void Update()
    {
        if (!_isInit) return;

        _roleController.Tick();
        _worldController.Tick();
        
    }

    // ============================================= 开始游戏 ==================================================
    private void GameStartController()
    {
        Debug.Log("开始游戏");
        var ev = EventRope.StartGameEvent;
        ev.SetIsTrigger(true);
        AllManager.EventManager.Broadcast(ev);
    }
    
}

