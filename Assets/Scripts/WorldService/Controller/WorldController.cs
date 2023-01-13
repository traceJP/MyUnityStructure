using System;
using System.Threading.Tasks;
using GameEvent.Entities.Impl;
using Global.Facades;
using UnityEngine;
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

            // TODO: 在 GameEvent 接收到世界生成 事件 后 生成世界
            AllManager.EventManager.AddListener<StartGameEvent>(action =>
            {
                SpawnWorld();
            });
            
        }
        
        
        
        public void Tick()
        {
            
        }
        

        private void SpawnWorld()
        {
            // 生成场景 -> 获取世界
            Action action = async () =>
            {
                const string sceneName = "Level1";
                var res = await Addressables.LoadSceneAsync(sceneName).Task;
                var worldGo = res.Scene.GetRootGameObjects()[0];
                var worldEntity = worldGo.GetComponent<WorldEntity>();

                // 找到世界的生成角色的坐标点位  &  生成角色
                var spawnPoint = worldEntity.SpawnerGroup.Find("ROLE_ORIGIN");
                
                // TODO：抛出事件 生成角色

                Debug.Log("世界生成完成");
            };
            action.Invoke();
            
        }
        
    }
}