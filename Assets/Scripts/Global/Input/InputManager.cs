using Input.Entities;
using UnityEngine;

namespace Input
{
    public class InputManager
    {
        
        // 输入实体
        private InputEntity _inputEntity;

        // 玩家操作实体
        public PlayerEntity PlayerEntity { get; private set; }
        
        public void Init()
        {
            // INIT
            _inputEntity = new InputEntity();
            PlayerEntity = new PlayerEntity();

            // BIND
            _inputEntity.OnMoveHandle += OnBindMoveToPlayer;
            _inputEntity.OnLookHandle += OnBindLookToPlayer;
        }

        private void OnBindMoveToPlayer(Vector2 vector2)
        {
            PlayerEntity.SetMoveAxis(vector2);
        }
        
        private void OnBindLookToPlayer(Vector2 vector2)
        {
            PlayerEntity.SetLookAxis(vector2);
        }
        
    }
}