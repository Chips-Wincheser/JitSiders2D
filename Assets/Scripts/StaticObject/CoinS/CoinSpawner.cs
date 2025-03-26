using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (var point in _spawnPoints)
        {
            Coin coin = Instantiate(_coinPrefab, point.position, Quaternion.identity);
            coin.Collected += OnCoinCollected;
        }
    }

    private void OnCoinCollected(Coin coin)
    {
        coin.Collected -= OnCoinCollected;
        Destroy(coin.gameObject);
    }
}