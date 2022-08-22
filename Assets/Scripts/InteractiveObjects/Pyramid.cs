using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pyramid : MonoBehaviour, IInteractable
    {
        public Vector3 Position => transform.position;
        
        [SerializeField]
        private InteractiveTrigger _interactiveTrigger;

        [SerializeField]
        private float _force;

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

        public void Interact(object sender) => 
            Jump();

        private void Jump() => 
            _rigidbody.AddForce(Vector3.up * _force, ForceMode.Force);
    }
}