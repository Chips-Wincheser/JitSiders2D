using System.Collections;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private StartCamera _camera;

    private float _value=0f;
    private bool _onPlayer = false;

    private void OnEnable()
    {
        if (_camera != null)
        {
            _camera.AimedOnPlayer+=TomblerOnPlayer;
        }
        else
        {
            _value=1f;
        }
    }

    private void OnDisable()
    {
        if (_camera != null)
            _camera.AimedOnPlayer-=TomblerOnPlayer;
    }

    private void LateUpdate()
    {
        if (_onPlayer || _camera == null)
            transform.position=new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y-_value, transform.position.z);
    }

    private void TomblerOnPlayer()
    {
        _onPlayer = true;
    }
}
