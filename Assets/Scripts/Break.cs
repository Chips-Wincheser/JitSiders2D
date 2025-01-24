using System;
using UnityEngine;

public class Break : MonoBehaviour
{
    private float _damage = 100;

    public event Action<float, bool> BreakDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out  Health PlayerHealth))
        {
            BreakDamage?.Invoke(_damage,true);
        }
    }
}
