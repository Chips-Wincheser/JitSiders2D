using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _TakeCoinClip;

    private List<Coin> _coins = new List<Coin>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins.Add(coin);
            _audioSource.PlayOneShot(_TakeCoinClip);
        }
    }
}
