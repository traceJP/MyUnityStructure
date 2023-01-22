using System;
using System.Threading.Tasks;
using Facades;
using GameEvent.Entities.Impl;
using UnityEngine.AddressableAssets;
using WorldService.Entities;
using WorldService.Facades;

namespace WorldService.Controller
{
    public class WorldController
    {

        public async Task Init()
        {
            // 加载世界资源
            await AllWorldAssetsRope.WorldAssets.LoadAllAssets();

            // 事件注册
            AllManager.EventManager.AddListener<WorldSpawnEvent>(OnSpawnWorldHandle);

        }
        
        
        public void Tick()
        {
            
        }

        private void OnSpawnWorldHandle(WorldSpawnEvent worldSpawnEvent)
        {
            Action action = async () =>
            {
                await SpawnWorld();
                // 生成角色
                var spawnPoint = AllWorldRope.WorldEntity.SpawnerGroup.Find("ROLE_ORIGIN");
                var roleSpawnEvent = AllEventRope.RoleSpawnEvent;
                roleSpawnEvent.SetSpawnPoint(spawnPoint.position);
                AllManager.EventManager.Broadcast(roleSpawnEvent);
            };
            action.Invoke();
        }
        
        private async Task SpawnWorld()
        {
            const string sceneName = "Level1";
            var res = await Addressables.LoadSceneAsync(sceneName).Task;
            var worldGo = res.Scene.GetRootGameObjects()[0];
            var worldEntity = worldGo.GetComponent<WorldEntity>();
            AllWorldRope.SetWorldEntity(worldEntity);
        }
        
    }
}