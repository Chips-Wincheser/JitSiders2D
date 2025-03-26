using System;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
    public event Action<PlayerInput> TriggerEntered;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<PlayerInput>(out PlayerInput player))
        {
            TriggerEntered?.Invoke(player);
        }
    }
}
