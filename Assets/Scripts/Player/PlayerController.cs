using System;
using System.Collections.Generic;
using Damage;
using DefaultNamespace;
using Player;
using Score;
using Services.Input;
using UI.Bars;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),
    typeof(Collider))]
public class PlayerController : MonoBehaviour, IDamageable, IScoreWriter, IScoreReader, IInteractiveHandler,
    IPickupHandler, ILookable, IPositionable
{
    public event Action OnDamaged;
    public event Action<int> OnScoreUpdated;
    public event Action<IInteractable> OnInteractiveEntered;
    public event Action<IInteractable> OnInteractiveExited;

    public Vector3 Position => transform.position;
    public Vector3 LookDirection => _lookDirection;

    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField]
    private PlayerPickup _playerPickup;

    [SerializeField, HideInInspector]
    private Rigidbody _rigidbody;

    [SerializeField, HideInInspector]
    private Collider _collider;

    private ISimpleInput _simpleInput;
    private int _currentScore;
    private List<IInteractable> _interactables = new List<IInteractable>();
    private Vector3 _lookDirection;
    private PlayerAgent _playerAgent;
    private PlayerDragging _playerDragging;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Construct(ISimpleInput simpleInput)
    {
        _simpleInput = simpleInput;

        _playerAgent = new PlayerAgent();
        _playerAgent.Construct(transform);

        _playerDragging = new PlayerDragging(_rigidbody, _playerAgent);
        
        _playerMovement.Construct(_rigidbody, simpleInput);
        _playerPickup.Construct(transform, _rigidbody, _collider, this);

        _lookDirection = transform.forward;
        
        _simpleInput.OnInteracted += Interact;
    }

    private void OnDestroy() => 
        DeInitialize();

    private void DeInitialize()
    {
        _simpleInput.OnInteracted -= Interact;
        
        _simpleInput = null;
    }

    private void Update()
    {
        _playerAgent.Tick();
        UpdateLook();
        _playerPickup.Tick();
    }

    private void FixedUpdate() => 
        _playerMovement.FixedTick();

    public void Spawn(Vector3 at)
    {
        transform.position = at;
        transform.rotation = Quaternion.identity;
    }

    public void TakeDamage() => 
        OnDamaged?.Invoke();

    public void Accrue(int score)
    {
        _currentScore += score;
        
        OnScoreUpdated?.Invoke(_currentScore);
    }

    public void EnterInteractive(IInteractable interactable)
    {
        if (_interactables.Contains(interactable))
            return;
        
        _interactables.Add(interactable);
        
        OnInteractiveEntered?.Invoke(interactable);
    }

    public void ExitInteractive(IInteractable interactable)
    {
        if (_interactables.Contains(interactable))
            _interactables.Remove(interactable);
        
        OnInteractiveExited?.Invoke(interactable);
    }

    public void HandlePickup(IPickable pickable) => 
        _playerPickup.HandlePickup(pickable);

    private void Interact()
    {
        for (int i = 0; i < _interactables.Count; i++) 
            _interactables[i].Interact(this);
    }

    private void UpdateLook()
    {
        Vector2 look = _simpleInput.LookAxis;
        
        if(look.magnitude >= 0.1f)
            _lookDirection = new Vector3(look.x, 0, look.y).normalized;
    }
}