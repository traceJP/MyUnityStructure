using Facades;    // 可以知道底层的存在
using Models;
using Role.Entities;
using UnityEngine;

namespace Controller
{
    /// <summary>
    /// 角色相关的业务逻辑
    ///
    /// </summary>
    public class RoleController
    {
        
        public RoleController()
        {
            
        }
        
        // 手动构造函数 对应着传统 MonoBehaviour 中的 Awake 方法
        public void Ctor()
        {
            
        }

        // 初始化函数 对应 MonoBehaviour 中的 Start 方法
        public void Init()
        {
            
        }

        // 每帧调用函数 MonoBehaviour 中的 Update 方法
        public void Tick()
        {
            // 业务逻辑3 玩家输入移动角色
            if (AllRepository.roleEntity != null)
            {
                // 按住空格键
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 调用角色实体类的移动方法
                    AllRepository.roleEntity.Move();
                }
            }
            
            // 拿到事件中心参数 判断是否需要生成角色 （即注册事件）
            StartGameEvent ev = AllEventCenter.StartGameEvent;
            if (ev.IsTrigger)    // 是否有其他地方触发了
            {
                ev.SetIsTrigger(false);
                SpawnRole(ev.Chapter, ev.Level);
            }

        }

        // 生成角色抽象方法
        private void SpawnRole(int chapter, int level)
        {
            // 生成角色 初始化角色 缓存角色
            RoleEntity role = AllManager.RoleManager.SpawnRole();
            role.Init();
            AllRepository.roleEntity = role;
        }

    }
}