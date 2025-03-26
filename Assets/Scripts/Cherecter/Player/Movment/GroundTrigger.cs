using System;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    public event Action Detected;
    public event Action Lost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectedCollision(Detected, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DetectedCollision(Lost, collision);
    }

    private void DetectedCollision(Action Action, Collider2D collision)
    {
        if ((_groundLayerMask & (1 << collision.gameObject.layer)) != 0)
        {
            Action?.Invoke();
        }
    }
}