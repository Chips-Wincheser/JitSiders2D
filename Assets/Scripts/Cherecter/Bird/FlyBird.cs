using UnityEngine;

public class FlyBird : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsContainer;
    [SerializeField] private float _stopThreshold = 0.1f;

    private Transform[] _points;

    private int _currentWaypoint = 0;
    private Vector3 _direction;

    private void Start()
    {
        _points = new Transform[_waypointsContainer.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] =_waypointsContainer.GetChild(i);
        }
    }

    private void Update()
    {
        _direction=_points[_currentWaypoint].position-transform.position;

        if (_direction.sqrMagnitude<_stopThreshold)
        {
            _currentWaypoint = ++_currentWaypoint % _points.Length;
        }
        else if(_currentWaypoint==0)
        {
            transform.position=_points[_currentWaypoint].position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentWaypoint].position,
            _speed * Time.deltaTime);
    }
}
