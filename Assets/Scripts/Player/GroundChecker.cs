using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private Transform _groundCheckPointDown;
    [SerializeField] private StickingWall _stickingWall = null;

    private bool _isGroundedDown;
    private bool _isSticking;

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;
    public event Action<bool> OnJumpBlocked;

    private void OnEnable()
    {
        _stickingWall.IsStickingAnimation += PlaySticking;
        _stickingWall.IsStopAnimation += StopSticking;
    }

    private void OnDisable()
    {
        _stickingWall.IsStickingAnimation -= PlaySticking;
        _stickingWall.IsStopAnimation -= StopSticking;
    }

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
        else if (_isSticking)
        {
            PlayerIsFlying?.Invoke();
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

    private void PlaySticking()
    {
        _isSticking = true;
    }

    private void StopSticking()
    {
        _isSticking = false;
    }
}
