using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InteractiveTrigger : MonoBehaviour
    {
        public event Action<IInteractiveHandler> OnEntered;
        public event Action<IInteractiveHandler> OnExited;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractiveHandler interactive)) 
                OnEntered?.Invoke(interactive);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractiveHandler interactive)) 
                OnExited?.Invoke(interactive);
        }
    }
}