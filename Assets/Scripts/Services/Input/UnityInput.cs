using System;
using Other;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace Services.Input
{
    public class UnityInput : ISimpleInput, IDeInitializable
    {
        public event Action<string> OnControlUpdated; 
        public event Action OnTaped;
        public event Action OnUpClicked;
        public event Action OnDownClicked;

        public Vector2 Axis => new Vector2(
            _controls.Gameplay.Movement_hor.ReadValue<float>(),
            _controls.Gameplay.Movement_ver.ReadValue<float>());

        private readonly Controls _controls;

        public UnityInput()
        {
            Debug.Log("Create UnityInput");
            
            _controls = new Controls();
            
            _controls.Enable();
            
            _controls.MainMenu.Click.performed += OnClickButtonDown;
            _controls.MainMenu.Move_down.performed += OnDownButtonDown;
            _controls.MainMenu.Move_up.performed += OnUpButtonDown;
            _controls.MainMenu.Mouse_hor.performed += OnMouseMoved;
            _controls.MainMenu.Mouse_ver.performed += OnMouseMoved;
            
            _controls.LevelMenu.Start.performed += OnStartButtonDown;

            InputSystem.onEvent += HandleInput;
        }

        private void HandleInput(InputEventPtr ptr, InputDevice device)
        {
            if (!ptr.IsA<StateEvent>() && !ptr.IsA<DeltaStateEvent>())
                return;
            
            var controls = device.allControls;
            var buttonPressPoint = InputSystem.settings.defaultButtonPressPoint;

            for (var i = 0; i < controls.Count; ++i)
            {
                var control = controls[i] as ButtonControl;
                
                if (control == null || control.noisy)
                    continue;
                
                if (control.ReadValueFromEvent(ptr, out var value) && value >= buttonPressPoint)
                {
                    OnControlUpdated?.Invoke(control.device.name);
                    
                    break;
                }
            }
        }

        public void DeInitialize()
        {
            _controls.Disable();
            
            _controls.MainMenu.Click.performed -= OnClickButtonDown;
            _controls.MainMenu.Move_down.performed -= OnDownButtonDown;
            _controls.MainMenu.Move_up.performed -= OnUpButtonDown;
            _controls.MainMenu.Mouse_hor.performed -= OnMouseMoved;
            _controls.MainMenu.Mouse_ver.performed -= OnMouseMoved;
            
            _controls.LevelMenu.Start.performed -= OnStartButtonDown;
        }

        private void OnMouseMoved(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            value = Mathf.Abs(value);
            
            float mouseOffsetPoint = 500f;

            if (value >= mouseOffsetPoint) 
                OnControlUpdated?.Invoke(context.control.device.name);
        }

        private void OnClickButtonDown(InputAction.CallbackContext context) => 
            OnTaped?.Invoke();

        private void OnStartButtonDown(InputAction.CallbackContext context) => 
            OnTaped?.Invoke();

        private void OnUpButtonDown(InputAction.CallbackContext context) => 
            OnUpClicked?.Invoke();

        private void OnDownButtonDown(InputAction.CallbackContext data) => 
            OnDownClicked?.Invoke();
    }
}