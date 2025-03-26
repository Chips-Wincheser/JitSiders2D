using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public event Action PickedUpCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin) && coin.IsUp==false )
        {
            coin.Collect();
            PickedUpCoin?.Invoke();
            _inventory.Coins.Add(coin);
        }
    }
}