using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Mover _movement;
    [SerializeField] private Jumper _jump;
    [SerializeField] private GroundChecker _groundDetector;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Health _health;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _runClip;
    [SerializeField] private AudioClip _LandClip;

    private int _fly = Animator.StringToHash("fly");
    private int _isRun = Animator.StringToHash("isRun");
    private int _isDie = Animator.StringToHash("IsDie");

    private bool _isJumped = false;
    private bool _inJump = true;
    private bool _hasLanded = true;

    private void OnEnable()
    {
        _playerInput.PlayerStanding += StopRunning;
        _movement.PlayerRuning += PlayRunning;
        _jump.Jumped += PlayJumping;
        _groundDetector.PlayerIsFlying += PlayFlying;
        _groundDetector.PlayerIsLanding += StopFlying;
        _health.PlayerDie+=Die;
    }

    private void OnDisable()
    {
        _playerInput.PlayerStanding -= StopRunning;
        _movement.PlayerRuning -= PlayRunning;
        _jump.Jumped -= PlayJumping;
        _groundDetector.PlayerIsFlying -= PlayFlying;
        _groundDetector.PlayerIsLanding -= StopFlying;
        _health.PlayerDie-=Die;
    }

    private void PlayRunning(float horizontal)
    {
        if (!_isJumped && horizontal != 0)
        {
            _animator.SetBool(_isRun, true);

            if (!_isJumped && !_inJump)
            {
                if (_audioSource.clip != _runClip || !_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                    _audioSource.clip = _runClip;
                    _audioSource.Play();
                }
            }
        }
    }

    private void StopRunning(float horizontal)
    {
        _animator.SetBool(_isRun, false);

        if(_audioSource.clip == _runClip)
            _audioSource.Stop();
    }

    private void PlayJumping()
    {
        _animator.SetInteger(_fly, 1);
        _isJumped = true;
        _inJump = true;
    }

    private void PlayFlying()
    {
        _animator.SetInteger(_fly, 0);
        _isJumped = false;
        _inJump = true;
        _hasLanded = false;
    }

    private void StopFlying()
    {
        if (!_isJumped && _hasLanded==false)
        {
            _animator.SetInteger(_fly, -1);
            _inJump = false;

            if (_LandClip != null)
            {
                _audioSource.PlayOneShot(_LandClip);
            }

            _hasLanded=true;
        }
    }

    private void Die()
    {
        _animator.SetBool(_isDie, true);
    }
}
