using System;
using Global.Entities.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.Entities
{
    public class InputEntity : InputActionsBase
    {
        
        public event Action<Vector2> OnMoveHandle; 

        public InputEntity()
        {
            Player.Move.started += OnMove;
            Player.Move.performed += OnMove;
            Player.Move.canceled += OnMove;
            Enable();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            OnMoveHandle?.Invoke(ctx.ReadValue<Vector2>());
        }
        
    }
}