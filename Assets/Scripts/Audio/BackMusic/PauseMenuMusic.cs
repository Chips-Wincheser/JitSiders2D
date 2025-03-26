using UnityEngine;
using UnityEngine.Audio;

public class PauseMenuMusic : MonoBehaviour
{
    private const float MinVolume = -80f;

    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private AudioSource _BackMusicInPauseMenu;

    private string _mixerBackMusic= "BackMusic";
    private string _mixerSound= "Sound";

    private void OnEnable()
    {
        _masterMixer.SetFloat(_mixerBackMusic, MinVolume);
        _masterMixer.SetFloat(_mixerSound, MinVolume);

        _BackMusicInPauseMenu.Play();
    }

    private void OnDisable()
    {
        _BackMusicInPauseMenu.Pause();
    }
}
