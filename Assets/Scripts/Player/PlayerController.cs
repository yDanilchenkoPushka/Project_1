using System;
using Damage;
using DefaultNamespace;
using Score;
using Services.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable, IScoreWriter, IScoreReader, IInteractiveHandler
{
    public event Action OnDamaged;
    public event Action<int> OnScoreUpdated;
    public event Action OnInteractiveEntered;
    public event Action OnInteractiveExited;
    
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _speed;

    private ISimpleInput _simpleInput;
    private int _currentScore;
    private IInteractable _interactable;

    public void Construct(ISimpleInput simpleInput) => 
        _simpleInput = simpleInput;

    private void OnDestroy() => 
        DeInitialize();

    private void DeInitialize() => 
        _simpleInput = null;

    private void FixedUpdate() => 
        Move(_simpleInput.Axis);

    private void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x * _speed, 0, direction.y * _speed);
        _rigidbody.AddForce(movement, ForceMode.Acceleration);
    }

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
        _interactable = interactable;

        _simpleInput.OnInteracted += Interact;
        
        OnInteractiveEntered?.Invoke();
    }

    public void ExitInteractive()
    {
        _simpleInput.OnInteracted -= Interact;
        
        _interactable = null;
        
        OnInteractiveExited?.Invoke();
    }

    public void Interact() => 
        _interactable?.Interact();
}