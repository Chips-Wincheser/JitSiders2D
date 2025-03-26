using UnityEngine;
using UnityEngine.Audio;

public class SoundDownloader : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private float _volumeMultiplier = 20f;
    [SerializeField] private string[] _mixerNames;
    [SerializeField] private UnityEngine.UI.Slider[] _sliders;

    private void Start()
    {
        for (int i = 0; i < _mixerNames.Length; i++)
        {
            if (PlayerPrefs.HasKey(_mixerNames[i])==false)
            {
                PlayerPrefs.SetFloat(_mixerNames[i], 0);
            }
            else
            {
                float value;
                value=PlayerPrefs.GetFloat(_mixerNames[i]);
                _masterMixer.SetFloat(_mixerNames[i], Mathf.Log10(value) * _volumeMultiplier);

                if (_sliders.Length!=0)
                {
                    _sliders[i].value = value;
                }
            }

            PlayerPrefs.Save();
        }
    }
}
