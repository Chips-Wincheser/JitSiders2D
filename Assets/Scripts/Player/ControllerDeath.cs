using System;
using System.Collections;
using UnityEngine;

public class ControllerDeath : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Mover _mover;
    [SerializeField]private Rigidbody2D _rigidbody;

    private WaitForSeconds _newWaitForSeconds;

    public event Action Risen;

    private void Awake()
    {
        float delay = 2;
        _newWaitForSeconds= new WaitForSeconds(delay);
    }

    private void OnEnable()
    {
        _health.PlayerDie+=Die;
    }

    private void OnDisable()
    {
        _health.PlayerDie-=Die;
    }

    private void Die()
    {
        StartCoroutine(DeathAnimationEnd());
    }

    private IEnumerator DeathAnimationEnd()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
        _mover.enabled = false;

        yield return _newWaitForSeconds;

        Risen?.Invoke();
        transform.position = _spawnPoint.position;
        _mover.enabled = true;
        _rigidbody.isKinematic = false;

        _health.IsDead=false;
    }
}
