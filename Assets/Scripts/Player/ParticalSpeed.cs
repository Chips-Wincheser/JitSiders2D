using UnityEngine;

public class ParticalSpeed : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private float _value = 1f;

    private void LateUpdate()
    {
        transform.position=new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y-_value, transform.position.z);
    }
}
