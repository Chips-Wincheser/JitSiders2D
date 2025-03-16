using System.Collections;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    [SerializeField] private Transform _endTarget;
    [SerializeField] private float _stopThreshold = 0.1f;

    private WaitForSeconds _waitForSeconds;
    private float _deley = 1f;
    private float _speed = 0.2f;
    private bool _onPlayer = false;


    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_deley);

        StartCoroutine(MovePlayer());
    }

    private IEnumerator MovePlayer()
    {
        yield return _waitForSeconds;

        while (_onPlayer==false)
        {
            if ((_endTarget.transform.position-transform.position).sqrMagnitude<_stopThreshold)
            {
                _onPlayer = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, _endTarget.transform.position, _speed);

            yield return null;
        }

    }
}
