using System;
using System.Collections;
using UnityEngine;

public class StartCamera : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private TeleportNextLevl _teleport;
    [SerializeField] private float _stopThreshold = 0.1f;

    private WaitForSeconds _waitForSeconds;
    private float _deley = 1f;
    private float _speed = 0.2f;
    private bool _onPlayer = false;

    public event Action AimedOnPlayer;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_deley);
        transform.position = new Vector3(_teleport.transform.position.x, _teleport.transform.position.y, transform.position.z);

        StartCoroutine(MovePlayer());
    }

    private IEnumerator MovePlayer()
    {
        yield return _waitForSeconds;

        while (_onPlayer==false)
        {
            if ((_playerMover.transform.position-transform.position).sqrMagnitude<_stopThreshold)
            {
                AimedOnPlayer?.Invoke();
                _onPlayer = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, _playerMover.transform.position, _speed);

            yield return Time.deltaTime;
        }

    }
}
