using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage=10f;

    private bool _inColision=false;

    public event Action<float,bool> EnemyDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerInput>(out PlayerInput player))
        {
            _inColision = true;
            EnemyDamage?.Invoke(_damage, _inColision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerInput>(out PlayerInput player))
        {
            _inColision = false;
            EnemyDamage?.Invoke(_damage, _inColision);
        }
    }
}
