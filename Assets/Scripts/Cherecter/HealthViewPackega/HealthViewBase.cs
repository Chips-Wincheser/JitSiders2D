using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    [SerializeField] protected Health _healthPlayer;

    private void OnEnable()
    {
        _healthPlayer.Updated += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        _healthPlayer.Updated -= UpdateCounterDisplay;
    }

    protected abstract void UpdateCounterDisplay(float health);
}
