using GameEvent.Entities.Impl;
using Global.Facades;
using UnityEngine;
using WorldService.Assets;
using WorldService.Entities;
using WorldService.Facades;

namespace WorldService.Controller
{

    public class RoleController
    {
        
        public void Ctor()
        {
            
        }

        public void Init()
        {
            
        }

        public void Tick()
        {

            AllManager.EventManager.AddListener<StartGameEvent>(action =>
            {
                SpawnRole();
            });

            // 业务逻辑3 玩家输入移动角色
            if (AllWorldRope.RoleEntity != null)
            {
                // 按住空格键
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 调用角色实体类的移动方法
                    AllWorldRope.RoleEntity.Move();
                }
            }
            
        }

        // 生成角色抽象方法
        private void SpawnRole()
        {
            // 生成角色 初始化角色 缓存角色
            AllWorldAssets.WorldAssets.RoleAssets.TryGetValue(WorldAssets.RoleAssetsEnum.RoleEntity, 
                out var rolePrefab);
            Debug.Assert(rolePrefab != null);
            var roleEntity = Object.Instantiate(rolePrefab).GetComponent<RoleEntity>();
            roleEntity.Init();
            AllWorldRope.SetRoleEntity(roleEntity);
        }

    }
}