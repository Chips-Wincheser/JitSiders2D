using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private void LateUpdate()
    {
        transform.position=new Vector3(_playerMover.transform.position.x, _playerMover.transform.position.y, transform.position.z);

    }
}
