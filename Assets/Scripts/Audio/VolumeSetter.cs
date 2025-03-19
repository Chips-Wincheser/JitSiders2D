using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    private const float MinVolume = -80f;

    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float _volumeMultiplier = 20f;
    [SerializeField] private string _mixerName;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        if (value > 0)
        {
            _masterMixer.SetFloat(_mixerName, Mathf.Log10(value) * _volumeMultiplier);
            PlayerPrefs.SetFloat(_mixerName, value);
        }
        else
        {
            _masterMixer.SetFloat(_mixerName, MinVolume);
            PlayerPrefs.SetFloat(_mixerName, MinVolume);
        }

        PlayerPrefs.Save();
    }
}