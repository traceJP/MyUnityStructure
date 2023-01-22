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
            _inputEntity.OnMoveHandle += OnBindPlayerEntity;
        }

        private void OnBindPlayerEntity(Vector2 vector2)
        {
            PlayerEntity.moveAxis = vector2;
        }
        
    }
}