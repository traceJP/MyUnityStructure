using System;
using Audio;
using Facades;
using Global.Controller;
using Global.Facades;
using UIRenderer;
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _isInit = false;
        
        // ================================================== CTOR ====================================================
        AllManager.Ctor();
        
        AllGlobalEventCenter.Ctor();
        
        AllGlobalRope.Ctor();
        AllWorldRope.Ctor();
        
        AllGlobalAssets.Ctor();
        AllWorldAssets.Ctor();

        _mainController = new MainController();
        _mainController.Ctor();
        _worldController = new WorldController();
        _worldController.Ctor();
        _roleController = new RoleController();
        _roleController.Ctor();
        
        
        // ======================================= INJECT =============================================================
        AllManager.SetUIManager(new UIManager());
        AllManager.SetAudioManager(new AudioManager());
        _mainController.Inject(
            transform.GetComponentInChildren<Canvas>(),
            transform.GetComponentInChildren<AudioSource>()
            );

        
        // ================================================= INIT =====================================================
        Action action = async () =>
        {
            await _mainController.Init();
            await _worldController.Init();
            _isInit = true;
        };
        action.Invoke();
      
    }
    
    
    private void Update()
    {
        if (!_isInit) return;

        _mainController.Tick();
        _roleController.Tick();
        
    }
}

