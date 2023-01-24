using System;
using Global.Entities.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input.Entities
{
    public class InputEntity : InputActionsBase
    {
        
        public event Action<Vector2> OnMoveHandle;

        public event Action<Vector2> OnLookHandle;

        public event Action<float> OnScrollHandle; 

        
        public InputEntity()
        {
            Player.Move.started += OnMove;
            Player.Move.performed += OnMove;
            Player.Move.canceled += OnMove;

            Player.Look.started += OnLook;
            Player.Look.performed += OnLook;
            Player.Look.canceled += OnLook;

            Player.Scroll.started += OnScroll;
            Player.Scroll.canceled += OnScroll;
            
            Enable();
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            OnMoveHandle?.Invoke(ctx.ReadValue<Vector2>());
        }
        
        private void OnLook(InputAction.CallbackContext ctx)
        {
            OnLookHandle?.Invoke(ctx.ReadValue<Vector2>());
        }
        
        private void OnScroll(InputAction.CallbackContext ctx)
        {
            OnScrollHandle?.Invoke(ctx.ReadValue<float>());
        }
        
    }
}