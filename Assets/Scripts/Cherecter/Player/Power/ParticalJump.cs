using System.Collections;
using UnityEngine;

public class ParticalJump : MonoBehaviour
{
    [SerializeField] private Jumper _playerJumper;
    [SerializeField] private ParticleSystem _particleSystem;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.05f); // Время отображения частиц
    private ParticleSystem.EmissionModule _emission;

    private void OnEnable()
    {
        _playerJumper.ParticalJumped += EnableParticle;
    }

    private void OnDisable()
    {
        _playerJumper.ParticalJumped -= EnableParticle;
    }

    private void Start()
    {
        _emission = _particleSystem.emission;
        _emission.enabled = false;
    }

    private void EnableParticle()
    {
        int loadPowers=PlayerPrefs.GetInt("CanDoubleJump");
        
        if (loadPowers != 0)
        {
            StartCoroutine(PlayParticle());
        }
    }

    private IEnumerator PlayParticle()
    {
        var _emission = _particleSystem.emission;
        _emission.enabled = true; // Включаем эмиссию частиц
        _particleSystem.Play();

        yield return _waitForSeconds;

        _emission.enabled = false; // Отключаем эмиссию частиц, но существующие частицы продолжают исчезать нормально
    }
}
