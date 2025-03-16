using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Image _health;

    private PostProcessVolume _blureEf;
    private bool _isPaused=false;

    private void Start()
    {
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            _blureEf = mainCamera.GetComponent<PostProcessVolume>();
            if (_blureEf == null)
            {
                Debug.LogError("PostProcessVolume не найден на главной камере!");
            }
        }
        else
        {
            Debug.LogError("Main Camera не найдена в сцене!");
        }
        _blureEf= Camera.main.GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused =!_isPaused;
            
            _blureEf.enabled = !_blureEf.enabled;
            _health.gameObject.SetActive(!_isPaused);

            if (_isPaused)
            {
                Time.timeScale = 0f;
                _pausePanel.SetActive(_isPaused);
            }
            else
            {
                Time.timeScale = 1f;
                _pausePanel.SetActive(_isPaused);
            }
        }
    }

    public void ButtonPlay()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _blureEf.enabled = false;
        _health.gameObject.SetActive(true);
        _isPaused=false ;
    }
}
