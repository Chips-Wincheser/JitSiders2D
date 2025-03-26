using UnityEngine;

public class CameraTeleport : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform tombler;
    [SerializeField] private float _stopThreshold;

    private void Update()
    {
        if ((transform.position - _mainCamera.transform.position).sqrMagnitude<_stopThreshold)
        {
            _mainCamera.enabled = false;
        }

        if((_mainCamera.transform.position -tombler.transform.position).sqrMagnitude<_stopThreshold)
        {
            _mainCamera.enabled = true;
        }
    }
}
