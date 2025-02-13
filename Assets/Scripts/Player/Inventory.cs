using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _TakeCoinClip;
    [SerializeField] private Button _button;

    private List<Coin> _coins = new List<Coin>();
    private string filePath;

    public bool CanHook { get; private set; }

    public event Action IsPicked;
    public event Action UsedHook;

    private void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "Scripts", "Player", "Inventory.txt");
        LoadCanHook();

        if (CanHook)
        {
            UsedHook?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins.Add(coin);
            _audioSource.PlayOneShot(_TakeCoinClip);
        }

        if (collision.TryGetComponent<Hook>(out Hook _))
        {
            IsPicked?.Invoke();
            _button.gameObject.SetActive(true);

            CanHook = true;
            SaveCanHook();
            UsedHook?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    public List<Coin> ShowCoinsList()
    {
        return _coins;
    }

    private void SaveCanHook()
    {
        File.WriteAllText(filePath, CanHook ? "1" : "0");
    }

    private void LoadCanHook()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            CanHook = data == "1";
        }
    }
}
