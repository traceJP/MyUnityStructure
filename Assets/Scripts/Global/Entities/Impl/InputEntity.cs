using System;
using System.Numerics;
using UnityEngine.InputSystem;

namespace Global.Entities.Impl
{
    public class InputEntity : InputActionsBase
    {
        
        public event Action<Vector2> OnMoveHandle; 

        public InputEntity()
        {
            Player.Move.started += OnMove;
            Enable();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            OnMoveHandle?.Invoke(ctx.ReadValue<Vector2>());
        }
        
    }
}