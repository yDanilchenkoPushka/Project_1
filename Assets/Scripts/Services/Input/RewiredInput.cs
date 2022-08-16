using System;
using Rewired;
using UnityEngine;

namespace DefaultNamespace
{
    public class RewiredInput : ISimpleInput
    {
        public event Action OnTaped;
        public Vector2 Axis => new Vector2(
            _player.GetAxis("Movement_hor"),
            _player.GetAxis("Movement_ver"));

        private readonly Rewired.Player _player;

        public RewiredInput(Rewired.Player player)
        {
            _player = player;

            _player.AddInputEventDelegate(OnStartButtonDown, UpdateLoopType.Update, "Start");
        }
        
        private void OnStartButtonDown(InputActionEventData data)
        {
            if (data.GetButtonDown()) 
                OnTaped?.Invoke();
        }
    }
}