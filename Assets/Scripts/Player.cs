using System;
using Damage;
using Score;
using Services.Input;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IScoreWriter, IScoreReader
{
    public event Action OnDamaged;
    public event Action<int> OnScoreUpdated; 

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _speed;

    private ISimpleInput _simpleInput;
    private int _currentScore;

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
}