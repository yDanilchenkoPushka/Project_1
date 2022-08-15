using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable)) 
                damageable.TakeDamage();
        }
    }
}