using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
    {
        private const float MinDistance = 1.5f;
        
        private bool CanFollow => _target != null;
        
        [SerializeField, HideInInspector]
        private NavMeshAgent _navMeshAgent;

        private IPositionable _target;

        private void OnValidate()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Construct(IPositionable target)
        {
            _target = target;
        }

        private void Update()
        {
            if(CanFollow)
                Follow();
        }

        private void Follow()
        {
            Vector3 direction = (_target.Position - transform.position).normalized;

            float distance = Vector3.Distance(_target.Position, transform.position);

            if (distance < MinDistance)
                return;

            Vector3 position = transform.position + direction * MinDistance;

            _navMeshAgent.SetDestination(position);
        }
    }
}