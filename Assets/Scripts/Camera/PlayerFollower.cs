using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private StartCamera _camera;
    [SerializeField] private int _speed;
    [SerializeField]private float _value;

    private bool _onPlayer = false;

    private void OnEnable()
    {
        _camera.AimedOnPlayer+=TomblerOnPlayer;
    }

    private void OnDisable()
    {
        _camera.AimedOnPlayer-=TomblerOnPlayer;
    }

    private void LateUpdate()
    {
        if (_onPlayer)
        {
            Vector3 targetPosition = new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y+_value, transform.position.z);
            transform.position=Vector3.Lerp(transform.position, targetPosition, _speed*Time.deltaTime);
        }
    }

    private void TomblerOnPlayer()
    {
        _onPlayer = true;
    }
}
