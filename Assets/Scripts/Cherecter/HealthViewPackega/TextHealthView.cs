using TMPro;
using UnityEngine;

public class TextHealthView : HealthViewBase
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        _counterText.text = _healthPlayer.MaxValue.ToString();
    }

    protected override void UpdateCounterDisplay(float health)
    {
        health*=_healthPlayer.MaxValue;
        _counterText.text = health.ToString();
    }
}