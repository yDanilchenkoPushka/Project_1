using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _speed;

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        
        Move(horizontalAxis, verticalAxis);
    }

    private void Move(float x, float y)
    {
        Vector3 movement = new Vector3(x * _speed, 0, y * _speed);
        _rigidbody.AddForce(movement, ForceMode.Acceleration);
    }

        
    public void Spawn(Vector3 at)
    {
        transform.position = at;
        transform.rotation = Quaternion.identity;
    }
}
