﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Services.Input
{
    public class InputService : IPlayerControl
    {
        public event Action OnPlayed;
        private readonly Controls _controls;

        public InputService()
        {
            _controls = new Controls();
        }

        public void Initialize()
        {
            _controls.Enable();

            _controls.LevelMenu.Play.performed += Play;
        }

        private void Play(InputAction.CallbackContext obj) => 
            OnPlayed?.Invoke();

        public void DeInitialize()
        {
            _controls.Disable();
            
            _controls.LevelMenu.Play.performed -= Play;
        }

        public Vector2 MovementAxis => new Vector2(
            _controls.Player.Movement_hor.ReadValue<float>(),
            _controls.Player.Movement_ver.ReadValue<float>());

    }
}