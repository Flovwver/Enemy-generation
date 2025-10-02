using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Target _target;

    private Rigidbody _rigidbody;

    private Vector3 DirectionToTarget 
    {
        get
        {
            if (_target == null)
                return Vector3.zero;

            var directionToTarget = (_target.transform.position - transform.position).normalized; 
            directionToTarget.y = 0;

            return directionToTarget;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    public void SetTarget(Target target)
    {
        if (target == null)
            return;

        _target = target;
    }

    private void MoveToTarget()
    {
        if (DirectionToTarget == Vector3.zero)
            return;

        _rigidbody.MovePosition(transform.position + _speed * DirectionToTarget);
    }
}
