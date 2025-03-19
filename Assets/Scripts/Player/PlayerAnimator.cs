using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _movement;
    [SerializeField] private Jumper _jump;
    [SerializeField] private GroundChecker _groundDetector;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Health _health;
    [SerializeField] private ControllerDeath _ControllerDeath;
    [SerializeField] private StickingWall _stickingWall = null;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");
    private int _isDie = Animator.StringToHash("IsDie");
    private int _isHooked = Animator.StringToHash("IsHooked");

    private bool _isJumped = false;
    private bool _hasLanded = true;
    private bool _isStiking = false;

    private void OnEnable()
    {
        _playerInput.PlayerStanding += StopRunning;
        _movement.PlayerRuning += PlayRunning;
        _jump.Jumped += PlayJumping;
        _groundDetector.PlayerIsFlying += PlayFlying;
        _groundDetector.PlayerIsLanding += StopFlying;
        _health.PlayerDie+=Die;
        _ControllerDeath.Risen+=Alive;
        _stickingWall.IsStickingAnimation+=PlayStiking;
        _stickingWall.IsStopAnimation+=StopStiking;
    }

    private void OnDisable()
    {
        _playerInput.PlayerStanding -= StopRunning;
        _movement.PlayerRuning -= PlayRunning;
        _jump.Jumped -= PlayJumping;
        _groundDetector.PlayerIsFlying -= PlayFlying;
        _groundDetector.PlayerIsLanding -= StopFlying;
        _health.PlayerDie-=Die;
        _ControllerDeath.Risen-=Alive;
        _stickingWall.IsStickingAnimation-=PlayStiking;
        _stickingWall.IsStopAnimation-=StopStiking;
    }

    private void PlayRunning(float horizontal)
    {
        if (!_isJumped && horizontal != 0)
        {
            _animator.SetBool(_isRun, true);
        }
    }

    private void StopRunning(float horizontal)
    {
        _animator.SetBool(_isRun, false);
    }

    private void PlayJumping()
    {
        _animator.SetInteger(_fly, 1);
        _isJumped = true;
    }

    private void PlayFlying()
    {
        if (_isStiking==false)
        {
            _animator.SetInteger(_fly, 0);
        }
        else
        {
            _animator.SetInteger(_fly, 2);
        }

        _isJumped = false;
        _hasLanded = false;
    }

    private void StopFlying()
    {
        if (!_isJumped && _hasLanded==false && _isStiking==false)
        {
            _animator.SetInteger(_fly, -1);

            _hasLanded=true;
        }
    }

    private void PlayStiking()
    {
        _animator.SetBool(_isHooked, true);
        _isStiking=true;
    }

    private void StopStiking()
    {
        _animator.SetBool(_isHooked, false);
        _isStiking=false;
    }

    private void Die()
    {
        _animator.SetBool(_isDie, true);
    }

    private void Alive()
    {
        _animator.SetBool(_isDie, false);
    }
}