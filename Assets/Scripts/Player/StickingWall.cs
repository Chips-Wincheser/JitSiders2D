using System;
using UnityEngine;

public class StickingWall : MonoBehaviour
{
    [SerializeField] private Wall _wall;
    [SerializeField] private PhysicsMaterial2D _slipperyMaterial;
    [SerializeField] private Inventory _inventory;

    public event Action IsStickingAnimation;
    public event Action IsStopAnimation;

    private void Start()
    {
        if (_inventory.CanHook==false)
            _slipperyMaterial.friction = 0.0f;
    }

    private void OnEnable()
    {
        _inventory.UsedHook+=CanUseHook;
    }

    private void OnDisable()
    {
        _inventory.UsedHook-=CanUseHook;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent <Wall>(out Wall _))
        {
            if(_inventory.CanHook)
                IsStickingAnimation?.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out Wall _))
        {
            IsStopAnimation?.Invoke();
        }
    }

    private void CanUseHook()
    {
        _slipperyMaterial.friction = 0.04f;
    }
}
