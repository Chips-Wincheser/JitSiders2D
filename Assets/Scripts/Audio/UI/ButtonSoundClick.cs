using UnityEngine;

public class ButtonSoundClick : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySoundClick()
    {
        _audioSource.Play();
    }
}
