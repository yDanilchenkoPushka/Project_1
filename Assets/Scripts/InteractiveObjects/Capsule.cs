using UnityEngine;

namespace DefaultNamespace
{
    public class Capsule : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private InteractiveTrigger _interactiveTrigger;
        
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
            handler.ExitInteractive();

        public void Interact()
        {
            Debug.Log("Interact with capsule");
        }
    }
}