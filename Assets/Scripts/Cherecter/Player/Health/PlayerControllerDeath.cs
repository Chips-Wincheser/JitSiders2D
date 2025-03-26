using System.Collections;
using UnityEngine;

public class PlayerControllerDeath : ControllerDeathBase
{
    [SerializeField] private Transform _spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<TriggerBoss>(out _))
        {
            _spawnPoint=collision.transform;
        }
    }

    protected override IEnumerator DeathAnimationEnd(float health)
    {
        MovmentLock.HandleMovement(_player.gameObject, true);

        yield return _newWaitForSeconds;
        //Risen?.Invoke(health);
         
        _player.position = _spawnPoint.position;
        transform.position = _spawnPoint.position;

        MovmentLock.HandleMovement(_player.gameObject, false);
        _health.Regeneration();
    }
}
