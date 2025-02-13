using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _poolSize = 3;
    [SerializeField] private Transform[] _spawnPoints;

    private Queue<Coin> _coinPool = new Queue<Coin>();

    private void Awake()
    {
        InitializePool();
        SpawnCoin();

        if (_poolSize > _spawnPoints.Length)
        {
            _poolSize = _spawnPoints.Length;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coinPool)
        {
            coin.PlayerPickedUp-=ReturnCoinToPool;
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Coin coin = Instantiate(_coinPrefab, transform);
            coin.gameObject.SetActive(false);
            _coinPool.Enqueue(coin);

            coin.PlayerPickedUp+=ReturnCoinToPool;
        }
    }

    private void SpawnCoin()
    {
        int spawnCount = _coinPool.Count;

        if (spawnCount > _spawnPoints.Length)
        {
            spawnCount = _spawnPoints.Length;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            Coin coin = _coinPool.Dequeue();
            coin.transform.position = _spawnPoints[i].position;
            coin.gameObject.SetActive(true);
        }
    }

    private void ReturnCoinToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _coinPool.Enqueue(coin);
    }
}
