using System;
using System.Collections.Generic;
using Damage;
using DefaultNamespace;
using Player;
using Score;
using Services.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, IScoreWriter, IScoreReader, IInteractiveHandler, IPickupHandler
{
    public event Action OnDamaged;
    public event Action<int> OnScoreUpdated;
    public event Action<IInteractable> OnInteractiveEntered;
    public event Action<IInteractable> OnInteractiveExited;
    
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Collider _collider;
    
    [SerializeField]
    private PlayerMovement _playerMovement;
    
    [SerializeField]
    private PlayerPickup _playerPickup;

    private ISimpleInput _simpleInput;
    private int _currentScore;
    private List<IInteractable> _interactables = new List<IInteractable>();

    public void Construct(ISimpleInput simpleInput)
    {
        _simpleInput = simpleInput;
        
        _playerMovement.Construct(_rigidbody, simpleInput);
        _playerPickup.Construct(transform, _rigidbody, _collider);
        
        _simpleInput.OnInteracted += Interact;
    }

    private void OnDestroy() => 
        DeInitialize();

    private void DeInitialize()
    {
        _simpleInput.OnInteracted -= Interact;
        
        _simpleInput = null;
    }

    private void Update() => 
        _playerPickup.Tick();

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
}