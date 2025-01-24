using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private List <Attack> _enemys;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathClip;

    private float _health;
    private float _healthMax=100;
    private float _healthMin=0;
    private float _delay=0.2f;

    private Coroutine _takeDamages;
    private WaitForSeconds _waitForSeconds;

    public event Action PlayerDie;
    public event Action<float> DownHealth;

    private void Awake()
    {
        _health = _healthMax;
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemys)
        {
            enemy.EnemyDamage+=PlayerHit;
        }
    }

    private void Update()
    {
        if( _health == _healthMin)
        {
            _audioSource.PlayOneShot(_deathClip,0.5f);
            PlayerDie?.Invoke();
            _health = _healthMax;
            DownHealth?.Invoke(_health);
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemys)
        {
            enemy.EnemyDamage-=PlayerHit;
        }
    }

    private void PlayerHit(float Damage,bool inColision)
    {
        if (inColision)
            _takeDamages= StartCoroutine(TakeDamage(Damage));
        else if(inColision==false || _health==_healthMin)
            StopCoroutine(_takeDamages);
    }

    private IEnumerator TakeDamage(float Damage)
    {
        while(_health > _healthMin)
        {
            _health-=Damage;

            if (_health >= _healthMin)
            {
                DownHealth?.Invoke(_health);
            }
            else
            {
                _health=_healthMin;
            }

            yield return _waitForSeconds;
        }

    }
}
