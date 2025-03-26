using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private EnemyPatrol _patrol;
    [SerializeField] private EnemyChaser _chaser;

    private Transform _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player == null && (((1 << collision.gameObject.layer) & _playerLayer) != 0))
        {
            _player = collision.transform;
            _chaser.StartChasing(_player);

            if (_patrol != null)
            {
                _patrol.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_player != null && collision.transform == _player)
        {
            _player = null;
            _chaser.StopChasing();

            if (_patrol != null)
            {
                _patrol.enabled = true;
            }
        }
    }
}
