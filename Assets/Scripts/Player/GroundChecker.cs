using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheckPointDown;

    private bool _isGroundedDown;

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;
    public event Action<bool> OnJumpBlocked;

    private void FixedUpdate()
    {
        PlayerStateNotifier();
    }

    private void PlayerStateNotifier()
    {
        _isGroundedDown = IsSurfaceDetected(_groundCheckPointDown);

        if (_isGroundedDown)
        {
            PlayerIsLanding?.Invoke();
            OnJumpBlocked?.Invoke(false);
        }
        else
        {
            PlayerIsFlying?.Invoke();
            OnJumpBlocked?.Invoke(true);
        }
    }

    private bool IsSurfaceDetected(Transform groundCheckPoint)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheckPoint.position, _groundCheckRadius);

        foreach (var hit in hits)
        {
            if (hit.GetComponent<Ground>() != null)
            {
                return true;
            }
        }

        return false;
    }
}
