using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    private const float MinVolume = -80f;

    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _volumeMultiplier = 20f;

    private float _musicLvl;

    public void SetVolume(string mixerName)
    {
        _musicLvl = _volumeSlider.value;

        if (_musicLvl > 0)
            _masterMixer.SetFloat(mixerName, Mathf.Log10(_musicLvl) * _volumeMultiplier);
        else
            _masterMixer.SetFloat(mixerName, MinVolume);
    }
}