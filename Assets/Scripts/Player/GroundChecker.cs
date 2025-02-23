using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private GroundTrigger _groundTrigger;
    [SerializeField] private StickingWall _stickingWall = null;

    private bool _isGroundedDown;

    public bool IsGrounded => _isGroundedDown;

    public event Action PlayerIsFlying;
    public event Action PlayerIsLanding;
    public event Action<bool> OnJumpBlocked;

    private bool _isSticking;

    private void OnEnable()
    {
        _stickingWall.IsStickingAnimation += PlaySticking;
        _stickingWall.IsStopAnimation += StopSticking;

        _groundTrigger.Detected+=TouchGround;
        _groundTrigger.Lost+=LostGround;
    }

    private void OnDisable()
    {
        _stickingWall.IsStickingAnimation -= PlaySticking;
        _stickingWall.IsStopAnimation -= StopSticking;

        _groundTrigger.Detected-=TouchGround;
        _groundTrigger.Lost-=LostGround;
    }

    private void FixedUpdate()
    {
        NotifyPlayerState();
    }

    private void NotifyPlayerState()
    {
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

    private void TouchGround()
    {
        _isGroundedDown= true;
    }

    private void LostGround()
    {
        _isGroundedDown= false;
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
