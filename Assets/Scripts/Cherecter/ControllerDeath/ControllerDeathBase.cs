using System;
using System.Collections;
using UnityEngine;

public abstract class ControllerDeathBase : MonoBehaviour
{
    [SerializeField] protected Transform _player;
    [SerializeField] protected Health _health;

    protected WaitForSeconds _newWaitForSeconds;

    public event Action<float> Risen;

    private void Awake()
    {
        float delay = 2;
        _newWaitForSeconds= new WaitForSeconds(delay);
    }

    private void OnEnable()
    {
        _health.Updated+=CheckDie;
    }

    private void OnDisable()
    {
        _health.Updated-=CheckDie;
    }

    private void CheckDie(float health)
    {
        if (health*_health.MaxValue<=0)
        {
            StartCoroutine(DeathAnimationEnd(health));
        }
    }

    protected abstract IEnumerator DeathAnimationEnd(float health);
}
