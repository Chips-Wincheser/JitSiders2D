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
    [SerializeField] private Image _hookUnknow;
    [SerializeField] private Image _jumpUnknow;

    private List<Coin> _coins = new List<Coin>();
    private string filePath;

    public bool CanHook { get; private set; }
    public bool CanDoubleJump { get; private set; }

    public event Action IsPicked;
    public event Action UsedHook;
    public event Action AcquiredDoubleJump;

    private void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "Scripts", "Player", "Inventory.txt");
        LoadInventory();

        if (CanHook)
        {
            UsedHook?.Invoke();
        }

        if (CanDoubleJump)
        {
            AcquiredDoubleJump?.Invoke();
        }

        _hookUnknow.gameObject.SetActive(!CanHook);
        _jumpUnknow.gameObject.SetActive(!CanDoubleJump);
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
            SaveInventory();
            UsedHook?.Invoke();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<DoubleJump>(out DoubleJump _))
        {
            IsPicked?.Invoke();
            _button.gameObject.SetActive(true);

            CanDoubleJump = true;
            SaveInventory();
            AcquiredDoubleJump?.Invoke();
            Destroy(collision.gameObject);
        }
    }

    public List<Coin> ShowCoinsList()
    {
        return _coins;
    }

    private void SaveInventory()
    {
        File.WriteAllText(filePath, $"{(CanHook ? "1" : "0")},{(CanDoubleJump ? "1" : "0")}");
    }

    private void LoadInventory()
    {
        if (File.Exists(filePath))
        {
            string[] data = File.ReadAllText(filePath).Split(',');
            if (data.Length >= 2)
            {
                CanHook = data[0] == "1";
                CanDoubleJump = data[1] == "1";
            }
        }
    }
}
