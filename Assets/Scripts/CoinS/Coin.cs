using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> PlayerPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Inventory>(out Inventory playerInventory))
        {
            PlayerPickedUp?.Invoke(this);
        }
    }
}
