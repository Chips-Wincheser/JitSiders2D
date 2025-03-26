using System.Collections;
using UnityEngine;


public class SmoothSliderHealthView : Slider
{
    [SerializeField] private float _smoothSpeed = 30f;

    private Coroutine _currentCoroutine;

    protected override void UpdateCounterDisplay(float health)
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine=StartCoroutine(SmoothHealthChange(health));
    }

    private IEnumerator SmoothHealthChange(float health)
    {
        while (SliderHealth.value != health)
        {
            SliderHealth.value = Mathf.MoveTowards(SliderHealth.value, health, _smoothSpeed * Time.deltaTime);
            yield return null;
        }

        _currentCoroutine = null;
    }
}
