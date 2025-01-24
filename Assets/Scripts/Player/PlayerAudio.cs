using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    /*[SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _Run;
    [SerializeField] private AudioClip _land;

    private bool _soundPlaed=false;

    private void OnEnable()
    {
        _playerAnimator.Laned+=Landing;
        _playerAnimator.PlayedJump+=PlayJumping;
    }

    private void OnDisable()
    {
        _playerAnimator.Laned-=Landing;
        _playerAnimator.PlayedJump-=PlayJumping;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            
            _audioSource.PlayOneShot(_land); Debug.Log("ѕроигрываем звук приземлени€ через основной AudioSource");
        }
    }

    private void Landing()
    {
        
        if (_soundPlaed==false)
        {
            _audioSource.Stop();
            _audioSource.PlayOneShot(_land);
            *//*_audioSource.clip = _land;
            _audioSource.loop = false;
            _audioSource.Play();*//*
            _soundPlaed = true;
        }
    }

    private void PlayJumping()
    {
        _soundPlaed=false;
    }*/
}
