using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Services.Input
{
    public class NewInput// : ISimpleInput
    {
        public event Action OnTaped;

        public Vector2 Axis => new Vector2(
            _controls.Player.Movement_hor.ReadValue<float>(),
            _controls.Player.Movement_ver.ReadValue<float>());

        private readonly Controls _controls;

        public NewInput()
        {
            _controls = new Controls();
            
            _controls.Enable();

            _controls.LevelMenu.Play.performed += Play;
        }

        public void DeInitialize()
        {
            _controls.Disable();
            
            _controls.LevelMenu.Play.performed -= Play;
        }

        private void Play(InputAction.CallbackContext obj) => 
            OnTaped?.Invoke();
    }
}