using System;
using Other;
using UnityEngine;
using UnityEngine.InputSystem;

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

            _controls.Gameplay.Movement_hor.performed += OnStickButtonDown;
            _controls.Gameplay.Movement_ver.performed += OnStickButtonDown;

            _controls.MainMenu.Click.performed += OnClickButtonDown;
            _controls.MainMenu.Move_down.performed += OnDownButtonDown;
            _controls.MainMenu.Move_up.performed += OnUpButtonDown;
            
            _controls.LevelMenu.Start.performed += OnStartButtonDown;
        }

        public void DeInitialize()
        {
            _controls.Disable();
            
            _controls.Gameplay.Movement_hor.performed -= OnStickButtonDown;
            _controls.Gameplay.Movement_ver.performed -= OnStickButtonDown;
            
            _controls.MainMenu.Click.performed -= OnClickButtonDown;
            _controls.MainMenu.Move_down.performed -= OnDownButtonDown;
            _controls.MainMenu.Move_up.performed -= OnUpButtonDown;
            
            _controls.LevelMenu.Start.performed -= OnStartButtonDown;
        }

        private void OnClickButtonDown(InputAction.CallbackContext data)
        {
            OnTaped?.Invoke();
            
            OnControlUpdated?.Invoke(data.control.ToString());
        }

        private void OnStartButtonDown(InputAction.CallbackContext data)
        {
            OnTaped?.Invoke();
            
            OnControlUpdated?.Invoke(data.control.ToString());
        }

        private void OnUpButtonDown(InputAction.CallbackContext data)
        {
            OnUpClicked?.Invoke();
            
            OnControlUpdated?.Invoke(data.control.ToString());
        }

        private void OnDownButtonDown(InputAction.CallbackContext data)
        {
            OnDownClicked?.Invoke();
            
            OnControlUpdated?.Invoke(data.control.ToString());
        }
        
        private void OnStickButtonDown(InputAction.CallbackContext data) => 
            OnControlUpdated?.Invoke(data.control.ToString());
    }
}