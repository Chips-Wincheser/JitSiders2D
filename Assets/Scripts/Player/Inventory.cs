using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _TakeCoinClip;
    [SerializeField] private Image _hookUnknow;
    [SerializeField] private Image _jumpUnknow;

    private List<Coin> _coins = new List<Coin>();

    public bool CanHook { get; private set; }
    public bool CanDoubleJump { get; private set; }

    public event Action IsPicked;
    public event Action UsedHook;
    public event Action AcquiredDoubleJump;

    private void Start()
    {
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

            CanHook = true;
            SaveInventory();
            UsedHook?.Invoke();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<DoubleJump>(out DoubleJump _))
        {
            IsPicked?.Invoke();
            
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
        PlayerPrefs.SetInt("CanHook", (CanHook ? 1 : 0));
        PlayerPrefs.SetInt("CanDoubleJump", (CanDoubleJump ? 1 : 0));
    }

    private void LoadInventory()
    {
        int loadPowers;

        loadPowers= PlayerPrefs.GetInt("CanHook");
        CanHook=(loadPowers != 0);

        loadPowers=PlayerPrefs.GetInt("CanDoubleJump");
        CanDoubleJump=(loadPowers != 0);
    }
}
