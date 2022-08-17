using System;
using Rewired;
using Services.Input.Factory;
using UnityEngine;

namespace DefaultNamespace
{
    public class RewiredInput : ISimpleInput, IDeInitializable
    {
        public event Action OnTaped;
        public event Action OnUpClicked;
        public event Action OnDownClicked;

        public Vector2 Axis => new Vector2(
            _player.GetAxis("Movement_hor"),
            _player.GetAxis("Movement_ver"));

        private readonly Rewired.Player _player;

        public RewiredInput(Rewired.Player player)
        {
            _player = player;

            _player.AddInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.AddInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            
            _player.AddInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.AddInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");
        }

        public void DeInitialize()
        {
            _player.RemoveInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.RemoveInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            _player.RemoveInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.RemoveInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");
        }

        private void OnTapButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown()) 
                OnTaped?.Invoke();
        }

        private void OnStartButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown()) 
                OnTaped?.Invoke();
        }
        
        private void OnUpButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown()) 
                OnUpClicked?.Invoke();
        }
        
        private void OnDownButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown()) 
                OnDownClicked?.Invoke();
        }
    }
}