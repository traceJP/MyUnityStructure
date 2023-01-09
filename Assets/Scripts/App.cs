using System;
using Controller;
using Facades;
using Global.Facades;
using Role;
using UIRenderer;
using UnityEngine;

public class App : MonoBehaviour
{

    private bool _isInit;
    
    // 主业务
    private MainController _mainController;
    
    // 角色业务
    private RoleController _roleController;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _isInit = false;
    }

    /// <summary>
    ///  这是整个程序（游戏）唯一一个入口 唯一一个Start，唯一一个Update。
    /// </summary>
    private void Start()
    {

        // ================================================== CTOR ====================================================
        AllAssets.Ctor();
        AllRepository.Ctor();
        AllManager.Ctor();
        AllEventCenter.Ctor();
        
        AllGlobalRope.Ctor();
        

        _mainController = new MainController();
        _mainController.Ctor();
        
        _roleController = new RoleController();
        _roleController.Ctor();


        // ======================================= INJECT 注入 ========= 管理器缓存进AllManager ==========================
        AllManager.RoleManager = new RoleManager();
        AllManager.SetUIManager(new UIManager());
        AllManager.UIManager.Inject(transform.GetComponentInChildren<Canvas>());

        // ================================================= INIT === Init 顺序一定是在所有的 ctor 的后面 =================
        Action action = async () =>
        {
            await _mainController.Init();
            _roleController.Init();
            _isInit = true;
        };
        action.Invoke();
        
        // =================================== CTOR INJECT INIt 三个流程结束后 游戏开始 ===============================
        
        
        

    }
    
    
    private void Update()
    {

        if (!_isInit)    // 等待所有 Init 执行完毕后 才可以开始 Tick
        {
            return;
        }
        
        _mainController.Tick();
        
        // 角色业务逻辑从 App 中分离到 RoleController 中
        _roleController.Tick();   // 手动调用 Tick 方法 以绑定 Update 方法
        
    }
}

