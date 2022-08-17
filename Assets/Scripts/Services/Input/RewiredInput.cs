using System;
using Other;
using Rewired;
using UnityEngine;

namespace Services.Input
{
    public class RewiredInput : ISimpleInput, IDeInitializable
    {
        public event Action<string> OnControlUpdated;
        public event Action OnTaped;
        public event Action OnUpClicked;
        public event Action OnDownClicked;

        public Vector2 Axis => new Vector2(
            _player.GetAxis("Movement_hor"),
            _player.GetAxis("Movement_ver"));

        private readonly Rewired.Player _player;

        public RewiredInput()
        {
            _player = ReInput.players.GetPlayer(0);

            _player.AddInputEventDelegate(OnStickButtonDown, UpdateLoopType.Update, "Movement_hor");
            _player.AddInputEventDelegate(OnStickButtonDown, UpdateLoopType.Update, "Movement_ver");
            
            _player.AddInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.AddInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            _player.AddInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.AddInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");
        }

        public void DeInitialize()
        {
            _player.RemoveInputEventDelegate(OnStickButtonDown, UpdateLoopType.Update, "Movement_hor");
            _player.RemoveInputEventDelegate(OnStickButtonDown, UpdateLoopType.Update, "Movement_ver");
            
            _player.RemoveInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.RemoveInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            _player.RemoveInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.RemoveInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");
        }

        private void OnStickButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown() || data.GetNegativeButtonDown()) 
                UpdateDeviceInfo();
        }

        private void OnTapButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown())
            {
                OnTaped?.Invoke();
                
                UpdateDeviceInfo();
            }
        }

        private void OnStartButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown())
            {
                OnTaped?.Invoke();
                
                UpdateDeviceInfo();
            }
        }
        
        private void OnUpButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown())
            {
                OnUpClicked?.Invoke();

                UpdateDeviceInfo();
            }
        }
        
        private void OnDownButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown())
            {
                OnDownClicked?.Invoke();

                UpdateDeviceInfo();
            }
        }

        private void UpdateDeviceInfo()
        {
            Controller controller = _player.controllers.GetLastActiveController();
            OnControlUpdated?.Invoke(controller.name);
        }
    }
}