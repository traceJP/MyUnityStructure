using System;
using Facades;
using TitleService.Controller;
using UnityEngine;
using WorldService.Controller;
using WorldService.Facades;

public class App : MonoBehaviour
{

    // 初始化标识
    private bool _isInit;

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
        // Global
        AllManager.Ctor();
        AllUIRendererRope.Ctor();
        AllEventRope.Ctor();
        AllGlobalRope.Ctor();
        
        // World
        AllWorldRope.Ctor();
        AllWorldAssetsRope.Ctor();
        
        // Controller
        _worldController = new WorldController();
        _roleController = new RoleController();
        _titlePageController = new TitlePageController();

        // ======================================= INJECT =============================================================
        AllGlobalRope.SetMainCamera(Camera.main);
        AllManager.UIManager.Inject(transform.GetComponentInChildren<Canvas>());
        AllManager.AudioManager.Inject(transform.GetComponentInChildren<AudioSource>());
        
        
        // ================================================= INIT =====================================================
        Action action = async () =>
        {
            // Global
            await AllManager.UIManager.Init();
            await AllManager.AudioManager.Init();
            AllManager.EventManager.Init();
            AllManager.InputManager.Init();
            
            // Service
            await _worldController.Init();
            _roleController.Init();
            _titlePageController.Init();
            
            // Init Over
            _isInit = true;
            GameStartController();
        };
        action.Invoke();
      
    }
    
    private void Update()
    {
        if (!_isInit) return;

        var deltaTime = Time.deltaTime;

    }

    private void FixedUpdate()
    {
        if (!_isInit) return;

        var fixedDeltaTime = Time.fixedDeltaTime;
        
        _roleController.FixedTick();
        _worldController.FixedTick();
        
    }

    // ============================================= 开始游戏 ==================================================
    private void GameStartController()
    {
        Debug.Log("开始游戏");
        
        // 抛出事件
        var ev = AllEventRope.StartGameEvent;
        ev.SetIsTrigger(true);
        AllManager.EventManager.Broadcast(ev);
    }
    
}

