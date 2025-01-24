using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.DownHealth += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        _health.DownHealth -= UpdateCounterDisplay;
    }

    private void UpdateCounterDisplay(float health)
    {
        if (_counterText != null)
        {
            _counterText.text = health.ToString();
        }
    }
}
