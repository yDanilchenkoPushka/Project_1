using System;
using Services.Input;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class PlayerMovement
    {
        [SerializeField]
        private float _speed = 14f;
        
        private Rigidbody _rigidbody;
        private ISimpleInput _simpleInput;

        public void Construct(Rigidbody rigidbody, ISimpleInput simpleInput)
        {
            _rigidbody = rigidbody;
            _simpleInput = simpleInput;
        }

        public void FixedTick() => 
            Move(_simpleInput.Axis);

        private void Move(Vector2 direction)
        {
            Vector3 movement = new Vector3(direction.x * _speed, 0, direction.y * _speed);
            _rigidbody.AddForce(movement, ForceMode.Acceleration);
        }
    }
}