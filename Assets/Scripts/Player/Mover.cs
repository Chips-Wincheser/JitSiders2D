using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private rotat _rotator;

    private Rigidbody2D _rigidbody2D;

    public event Action<float> PlayerRuning;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Runing+=ProcessHorizontalInput;
    }

    private void OnDisable()
    {
        _playerInput.Runing-=ProcessHorizontalInput;
    }

    private void ProcessHorizontalInput(float horizontal)
    {
        _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
        _rotator.Rotate(horizontal);

        PlayerRuning?.Invoke(horizontal);
    }
}