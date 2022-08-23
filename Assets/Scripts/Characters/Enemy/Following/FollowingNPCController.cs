using System;
using Characters.Enemy.Following.States;
using Infrastructure;
using Infrastructure.Processors.Tick;
using Interactive;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy.Following
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowingNPCController : MonoBehaviour, IInteractable, ITargetInfo
    {
        public event Action OnTargetUpdated;
        public bool HasTarget => _target != null;
        public IEnemyTarget Target => _target;

        public Vector3 Position => transform.position;

        private const float MinDistance = 2f;

        [SerializeField, HideInInspector]
        private NavMeshAgent _agent;

        private IStateMachine _stateMachine;
        private IEnemyTarget _target;
        
        private void OnValidate()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Construct(ITickProcessor tickProcessor)
        {
            StateMachine stateMachine = new StateMachine();
            
            _stateMachine = stateMachine;
            
            stateMachine.RegisterStates(
                new IdleState(_stateMachine, this),
                new FollowingState(_stateMachine, transform, _agent, MinDistance, this, tickProcessor));

            _stateMachine.ChangeState<IdleState>();
        }

        public void Interact(object sender)
        {
            if (sender is IEnemyTarget target)
            {
                _target = HasTarget ? null : target;
                OnTargetUpdated?.Invoke();
            }
        }
    }
}