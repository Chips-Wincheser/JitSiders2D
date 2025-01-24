using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ÑontrollerDeath : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _spawnPoint;

    //public event

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
        transform.position = _spawnPoint.position;
    }
}
