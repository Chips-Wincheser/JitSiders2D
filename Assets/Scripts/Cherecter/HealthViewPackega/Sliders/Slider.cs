using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class Slider : HealthViewBase
{
    [SerializeField] protected UnityEngine.UI.Slider SliderHealth;

    private void Awake()
    {
        SliderHealth = GetComponent<UnityEngine.UI.Slider>();
    }

    protected override void UpdateCounterDisplay(float health) { }
}