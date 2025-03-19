using UnityEngine;
using UnityEngine.Audio;

public class PauseMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _BackgroundMusic;

    private void OnEnable()
    {
        _audioSource.Play();
        _BackgroundMusic.Pause();
    }

    private void OnDisable()
    {
        _audioSource.Pause();
        _BackgroundMusic.Play();
    }
}
