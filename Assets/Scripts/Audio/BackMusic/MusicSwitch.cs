using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        _audioSource.clip = _audioClips[currentSceneIndex];
        _audioSource.Play();
    }
}
