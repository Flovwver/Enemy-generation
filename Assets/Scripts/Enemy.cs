using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector3 _moveDirection = Vector3.forward;

    private Rigidbody _rigidbody;

    public Vector3 MoveDirection
    {
        get => _moveDirection;
        set
        {
            if (value == Vector3.zero)
                return;
            _moveDirection = value.normalized;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _moveSpeed * _moveDirection);
    }
}
