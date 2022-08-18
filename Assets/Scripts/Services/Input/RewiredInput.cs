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
            
            _player.AddInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.AddInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            _player.AddInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.AddInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");

            _player.AddInputEventDelegate(UpdateDeviceInfo, UpdateLoopType.Update);
        }

        public void DeInitialize()
        {
            _player.RemoveInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
            _player.RemoveInputEventDelegate(OnTapButtonDown, UpdateLoopType.Update, "Click");
            
            _player.RemoveInputEventDelegate(OnUpButtonDown, UpdateLoopType.Update, "Move_up");
            _player.RemoveInputEventDelegate(OnDownButtonDown, UpdateLoopType.Update, "Move_down");
            
            _player.RemoveInputEventDelegate(UpdateDeviceInfo, UpdateLoopType.Update);
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

        private void UpdateDeviceInfo(InputActionEventData eventData)
        {
            CheckMouse();
            CheckJoysticks();
            CheckKeyboards();
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

        private void CheckMouse()
        {
            var mouse = ReInput.controllers.Mouse;

            if(IsActiveMouse(mouse))
                OnControlUpdated?.Invoke(mouse.name);
        }

        private void CheckJoysticks()
        {
            var joysticks = ReInput.controllers.Joysticks;

            foreach (var joystick in joysticks)
            {
                if (IsActiveJoystick(joystick))
                {
                    OnControlUpdated?.Invoke(joystick.name);
                    
                    break;
                }
            }
        }

        private void CheckKeyboards()
        {
            var keyboard = ReInput.controllers.Keyboard;

            for (int i = 0; i < keyboard.buttonCount; i++)
            {
                if (keyboard.GetButtonDown(i))
                {
                    OnControlUpdated?.Invoke(keyboard.name);
                    
                    break;
                }
            }
        }

        private bool IsActiveMouse(Mouse mouse)
        {
            for (int i = 0; i < mouse.buttonCount; i++)
            {
                if (mouse.GetButtonDown(i))
                    return true;
            }

            float offsetPoint = 0.05f;
            for (int i = 0; i < mouse.axisCount; i++)
            {
                if (mouse.GetAxis(i) >= offsetPoint)
                    return true;
            }

            for (int i = 0; i < mouse.axis2DCount; i++)
            {
                if (mouse.GetAxis2D(i).magnitude >= offsetPoint)
                    return true;
            }

            return false;
        }

        private bool IsActiveJoystick(Joystick joystick)
        {
            for (int i = 0; i < joystick.buttonCount; i++)
            {
                if (joystick.GetButtonDown(i))
                    return true;
            }

            float offsetPoint = 0.05f;
            for (int i = 0; i < joystick.axisCount; i++)
            {
                if (joystick.GetAxis(i) >= offsetPoint)
                    return true;
            }
            
            for (int i = 0; i < joystick.axis2DCount; i++)
            {
                if (joystick.GetAxis2D(i).magnitude >= offsetPoint)
                    return true;
            }

            return false;
        }
    }
}