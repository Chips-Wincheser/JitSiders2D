using UnityEngine;
using System;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float _attackThreshold = 2f;
    [SerializeField] private EnemyMover _mover;

    private Transform _target;

    public event Action<bool> CameClose;

    private void FixedUpdate()
    {
        if (_target != null)
        {
            _mover.MoveTo(_target.position);
            _mover.RotateTowards(_target);

            float distanceSqr = (_target.position - transform.position).sqrMagnitude;
            bool isClose = distanceSqr < _attackThreshold;
            CameClose?.Invoke(isClose);
        }
    }

    public void StartChasing(Transform target)
    {
        _target = target;
        enabled = true;
    }

    public void StopChasing()
    {
        _target = null;
        enabled = false;
        CameClose?.Invoke(false);
    }
}
