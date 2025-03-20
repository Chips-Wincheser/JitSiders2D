using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool IsUp {  get; private set; }

    public event Action<Coin> Collected;

    private void Start()
    {
        IsUp = false;
    }

    public void Collect()
    {
        IsUp=true;
        Collected?.Invoke(this);
    }
}