using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Collider2D _patrollÀrea;
    [SerializeField] private rotat _rotatetor;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _runClip;

    private float _direction;
    private float _areaMin;
    private float _areaMax;
    private Rigidbody2D _rigidbody2D;
    private bool _isAtEndPoint = false;

    private void Awake()
    {
        _rigidbody2D=GetComponent<Rigidbody2D>();
        _direction = 1;

        _areaMin = _patrollÀrea.bounds.min.x;
        _areaMax = _patrollÀrea.bounds.max.x;
    }

    private void OnEnable()
    {
        _audioSource.Play();
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - _areaMax) < 0.1f || Mathf.Abs(transform.position.x - _areaMin) < 0.1f)
        {
            if (_isAtEndPoint==false)
            {
                _direction=-_direction;
                _rotatetor.Rotate(_direction);
                _isAtEndPoint = true;
            }
        }
        else
        {
            _isAtEndPoint=false;
        }

        _rigidbody2D.velocity = new Vector2(_direction * _speed, _rigidbody2D.velocity.y);
    }
}