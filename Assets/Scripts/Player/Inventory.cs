using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Coin> Coins { get; private set; }

    public bool CanHook { get; private set; }
    public bool CanDoubleJump { get; private set; }

    public event Action IsPicked;
    public event Action UsedHook;
    public event Action AcquiredDoubleJump;
    public event Action<bool,string> UsedPower;

    private void Start()
    {
        Coins= new List<Coin>();

        LoadInventory();

        if (CanHook)
        {
            UsedHook?.Invoke();
            UsedPower?.Invoke(CanHook,"hook");
        }

        if (CanDoubleJump)
        {
            AcquiredDoubleJump?.Invoke();
            UsedPower?.Invoke(CanDoubleJump, "jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        return Coins;
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
