using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _waypointReachThreshold = 1f;
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private int _currentWaypointNumber;

    private bool HaveWaypoints => _waypoints != null && _waypoints.Count > 0;

    private void FixedUpdate()
    {
        MoveToCurrentWaypoint();
    }

    private void MoveToCurrentWaypoint()
    {
        if (HaveWaypoints == false)
            return;
        
        Transform waypoint = _waypoints[_currentWaypointNumber];
        Vector3 direction = waypoint.position - transform.position;

        transform.Translate(direction.normalized * _moveSpeed, Space.World);

        if (Vector3.Distance(transform.position, waypoint.position) < _waypointReachThreshold)
        {
            _currentWaypointNumber++;

            if (_currentWaypointNumber >= _waypoints.Count)
            {
                _currentWaypointNumber = 0;
            }
        }
    }
}
