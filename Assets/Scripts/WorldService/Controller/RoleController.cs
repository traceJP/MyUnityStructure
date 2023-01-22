using Facades;
using GameEvent.Entities.Impl;
using UnityEngine;
using WorldService.Assets;
using WorldService.Entities;
using WorldService.Facades;

namespace WorldService.Controller
{

    public class RoleController
    {

        public void Init()
        {
            
            AllManager.EventManager.AddListener<RoleSpawnEvent>(SpawnRole);
        }

        public void Tick()
        {
            
            // 业务逻辑3 玩家输入移动角色
            if (AllWorldRope.RoleEntity != null)
            {
                var moveAxis = AllManager.InputManager.PlayerEntity.moveAxis;
                AllWorldRope.RoleEntity.Move(moveAxis);
            }
            
        }

        // 生成角色
        private void SpawnRole(RoleSpawnEvent roleSpawnEvent)
        {
            AllWorldAssetsRope.WorldAssets.RoleAssets.TryGetValue(WorldAssets.RoleAssetsEnum.RoleEntity, 
                out var rolePrefab);
            Debug.Assert(rolePrefab != null);
            var roleEntity = Object.Instantiate(rolePrefab).GetComponent<RoleEntity>();
            roleEntity.transform.position = roleSpawnEvent.SpawnPoint;
            AllWorldRope.SetRoleEntity(roleEntity);
            Debug.Log("生成角色");
        }

    }
}