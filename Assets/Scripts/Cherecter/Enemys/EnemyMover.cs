using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private rotat _rotator;
    public float DirectionX { get; private set; }

    private void Awake()
    {
        DirectionX = 1;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    public void RotateTowards(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        float newDirection = Mathf.Sign(direction.x);
        if (newDirection != DirectionX)
        {
            DirectionX = newDirection;
            _rotator?.Rotate(DirectionX);
        }
    }
}
