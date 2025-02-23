using System;
using UnityEngine;
using System.Collections;

public class TeleportNextLevl : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _isActive = Animator.StringToHash("isActive");
    private int _lock = Animator.StringToHash("Lock");

    private WaitForSeconds _waitForSeconds;

    public event Action<Collider2D> FinishedLevl;

    private void Start()
    {
        _waitForSeconds= new WaitForSeconds(2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Mover>(out Mover player))
        {
            if (collision.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            {
                _animator.SetBool(_lock, true);
                spriteRenderer.sortingOrder = -50;

                StartCoroutine(Wait(collision));
            }
        }
    }

    private IEnumerator Wait(Collider2D collision)
    {
        yield return _waitForSeconds;
        FinishedLevl?.Invoke(collision);
    }
}
