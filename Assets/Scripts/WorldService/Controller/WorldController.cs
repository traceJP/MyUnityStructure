using System;
using System.Threading.Tasks;
using GameEvent.Entities.Impl;
using GameEvent.Facades;
using Global.Facades;
using UnityEngine.AddressableAssets;
using WorldService.Entities;
using WorldService.Facades;

namespace WorldService.Controller
{
    public class WorldController
    {
        public void Ctor()
        {
            
        }
        
        public async Task Init()
        {
            // 加载世界资源
            await AllWorldAssets.WorldAssets.LoadAllAssets();

            // 开始游戏
            AllManager.EventManager.AddListener<StartGameEvent>(OnHandleStartGame);

        }
        
        
        
        public void Tick()
        {
            
        }

        private void OnHandleStartGame(StartGameEvent startGameEvent)
        {
            Action action = async () =>
            {
                await SpawnWorld();
                // 生成角色
                var spawnPoint = AllWorldRope.WorldEntity.SpawnerGroup.Find("ROLE_ORIGIN");
                var roleSpawnEvent = EventRope.RoleSpawnEvent;
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