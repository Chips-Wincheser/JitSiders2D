using System.Collections;
using UnityEngine;

public class BossMoverController : MonoBehaviour
{
    [SerializeField] private TriggerBoss _trigger;
    [SerializeField] private BossAnimator _animator;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private ParticleSystem _particleSlis;

    private ParticleSystem.EmissionModule _emission;

    private WaitForSeconds _waitForSeconds;
    private int delay=5;

    private bool isAlive=true;

    private void Awake()
    {
        _emission=_particleSlis.emission;
        _emission.enabled = false;
        _waitForSeconds = new WaitForSeconds(delay);
        _enemyPatrol.enabled=false;
    }

    private void OnEnable()
    {
        _trigger.TriggerEntered+=EnableActiveStage;
        _health.Updated+=CheckingHP;
    }

    private void OnDisable()
    {
        _trigger.TriggerEntered-=EnableActiveStage;
        _health.Updated-=CheckingHP;
    }

    private void EnableActiveStage(PlayerInput player)
    {
        StartCoroutine(StartFight(player));
    }

    private IEnumerator StartFight(PlayerInput player)
    {
        while (isAlive)
        {
            yield return _waitForSeconds;

            _enemyPatrol.enabled=true;
            _animator.Run(true);

            yield return _waitForSeconds;

            _enemyPatrol.enabled=false;
            _animator.Run(false);

            _animator.Attack(true);
            _emission.enabled = true;

            yield return _waitForSeconds;

            _emission.enabled = false;
            _animator.Attack(false);
        }
    }

    private void CheckingHP(float health)
    {
        if (health*_health.MaxValue<=0)
        {
            isAlive=false;
            Destroy(gameObject);
        }
    }
}
