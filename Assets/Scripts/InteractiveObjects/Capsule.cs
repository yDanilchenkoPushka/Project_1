using Player;
using UnityEngine;

namespace DefaultNamespace
{
    public class Capsule : MonoBehaviour, IInteractable, IPickable
    {
        public Rigidbody Rigidbody => _rigidbody;
        public Transform Transform => transform;
        public Vector3 Position => transform.position;
        public Collider Collider => _collider;
        
        [SerializeField]
        private InteractiveTrigger _interactiveTrigger;

        [SerializeField]
        private Collider _collider;

        [SerializeField, HideInInspector]
        private Rigidbody _rigidbody;

        private void OnValidate() => 
            _rigidbody = GetComponent<Rigidbody>();

        private void Awake()
        {
            _interactiveTrigger.OnEntered += EnterInteractive;
            _interactiveTrigger.OnExited += ExitInteractive;
        }
        
        private void EnterInteractive(IInteractiveHandler handler) => 
            handler.EnterInteractive(this);

        private void ExitInteractive(IInteractiveHandler handler) => 
            handler.ExitInteractive(this);

        public void Interact(object sender)
        {
            if(sender is IPickupHandler handler)
                handler.HandlePickup(this);
        }
    }
}