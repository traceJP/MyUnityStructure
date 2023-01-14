﻿using GameEvent.Entities.Impl;
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
            AllManager.EventManager.AddListener<RoleSpawnEvent>(SpawnRole);
        }

        public void Tick()
        {
            
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

        // 生成角色
        private void SpawnRole(RoleSpawnEvent roleSpawnEvent)
        {
            AllWorldAssets.WorldAssets.RoleAssets.TryGetValue(WorldAssets.RoleAssetsEnum.RoleEntity, 
                out var rolePrefab);
            Debug.Assert(rolePrefab != null);
            var roleEntity = Object.Instantiate(rolePrefab).GetComponent<RoleEntity>();
            roleEntity.transform.position = roleSpawnEvent.SpawnPoint;
            AllWorldRope.SetRoleEntity(roleEntity);
        }

    }
}