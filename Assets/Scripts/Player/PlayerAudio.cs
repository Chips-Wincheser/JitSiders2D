using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Collector _collector;

    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _runClip;
    [SerializeField] private AudioClip _LandClip;
    [SerializeField] private AudioClip _TakeCoinClip;

    private bool _canPlayJumpSound=false;

    private void OnEnable()
    {
        _playerInput.Jumping+=JumpSound;
        _playerInput.Runing+=RunSound;
        _groundChecker.PlayerIsLanding += LandSound;
        _groundChecker.OnJumpBlocked += UpdateJumpState;
        _collector.PickedUpCoin +=TakeCoinSound;
    }

    private void OnDisable()
    {
        _playerInput.Jumping-=JumpSound;
        _playerInput.Runing-=RunSound;
        _groundChecker.PlayerIsLanding -= LandSound;
        _groundChecker.OnJumpBlocked -= UpdateJumpState;
        _collector.PickedUpCoin -=TakeCoinSound;

    }

    private void JumpSound()
    {
        if(_canPlayJumpSound)
            _audioSource.PlayOneShot(_jump,0.5f);
    }
    
    private void LandSound()
    {
        _audioSource.PlayOneShot(_LandClip);
    }

    private void RunSound(float horizontal)
    {

        if (horizontal!=0 && _groundChecker.IsGrounded)
        {
            if (!_audioSource.isPlaying || _audioSource.clip != _runClip)
            {
                _audioSource.clip = _runClip;
                _audioSource.loop = true;
                _audioSource.pitch = Random.Range(0.9f, 1.1f);
                _audioSource.Play();
            }
        }
        else if (_audioSource.isPlaying && _audioSource.clip == _runClip)
        {
            StopSound();
        }
    }

    private void TakeCoinSound()
    {
        _audioSource.PlayOneShot(_TakeCoinClip);
    }

    private void StopSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.loop = false;
            _audioSource.clip = null;
            _audioSource.pitch =1f;
        }
    }

    private void UpdateJumpState(bool jumpBlocked)
    {
        _canPlayJumpSound=!jumpBlocked;
    }
}
