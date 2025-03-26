using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Image _health;
    [SerializeField] private Camera _mainCamera;

    private PostProcessVolume _blureEf;
    private bool _isPaused=false;

    private void Start()
    {
        if (_mainCamera != null)
        {
            _blureEf = _mainCamera.GetComponent<PostProcessVolume>();

            if (_blureEf == null)
            {
                Debug.LogError("PostProcessVolume �� ������ �� ������� ������!");
            }
        }
        else
        {
            Debug.LogError("Main Camera �� ������� � �����!");
        }
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
