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

    public bool IsDead=false;

    public event Action PlayerDie;
    public event Action PlayerDieAnimation;
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
            IsDead = true;

            if(_takeDamages != null)
                StopCoroutine(_takeDamages);
            
            _audioSource.PlayOneShot(_deathClip,0.5f);

            PlayerDie?.Invoke();
            PlayerDieAnimation?.Invoke();

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
        if (inColision && _health!=_healthMin)
            _takeDamages= StartCoroutine(TakeDamage(Damage));
        else if(inColision==false)
            StopCoroutine(_takeDamages);
    }

    private IEnumerator TakeDamage(float Damage)
    {
        while(_health > _healthMin && IsDead==false)
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
