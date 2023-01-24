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
            Look();
        }
        
        public void FixedTick()
        {
            Move();
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

        }

        // 角色移动控制
        private void Move()
        {
            var roleCamera = AllWorldRope.RoleCamera;
            if (AllWorldRope.RoleEntity == null || roleCamera == null)
            {
                return;
            }
            var moveAxis = AllManager.InputManager.PlayerEntity.MoveAxis;
            AllWorldRope.RoleEntity.Move(moveAxis, roleCamera.transform);
        }

        // 角色第三人称相机控制
        private void Look()
        {
            var roleCamera = AllWorldRope.RoleCamera;
            var roleEntity = AllWorldRope.RoleEntity;
            if (roleEntity == null || roleCamera == null)
            {
                return;
            }
            
            // 相机跟随
            roleCamera.Follow(roleEntity.standThirdPersonCameraRoot);
            
            // 相机旋转
            var lookAxis = AllManager.InputManager.PlayerEntity.LookAxis;
            roleCamera.Rotate(lookAxis);
            
            // 相机视距
            var scroll = AllManager.InputManager.PlayerEntity.PullDistance;
            roleCamera.PullDistance(scroll);

        }

    }
}