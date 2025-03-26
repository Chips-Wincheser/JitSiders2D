using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _stopThreshold = 0.1f;
    [SerializeField] private EnemyMover _mover;
    
    private int _currentWaypoint = 0;

    private void Update()
    {
        Transform targetWaypoint = _wayPoints[_currentWaypoint];
        _mover.MoveTo(targetWaypoint.position);
        _mover.RotateTowards(targetWaypoint);

        Vector3 toWaypoint = targetWaypoint.position - transform.position;

        if (toWaypoint.sqrMagnitude < _stopThreshold)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
        }
    }
}
