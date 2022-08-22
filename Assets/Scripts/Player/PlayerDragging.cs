using UnityEngine;

namespace Player
{
    public class PlayerDragging
    {
        private readonly Rigidbody _rigidbody;
        private readonly PlayerAgent _playerAgent;

        public PlayerDragging(Rigidbody rigidbody, PlayerAgent playerAgent)
        {
            _rigidbody = rigidbody;
            _playerAgent = playerAgent;

            _playerAgent.OnAreaChanged += OnAreaChanged;
        }

        private void OnAreaChanged(float coast) => 
            _rigidbody.drag = coast - 1f;
    }
}