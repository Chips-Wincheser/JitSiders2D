using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GroundChecker _groundDetector;
    [SerializeField] private Inventory _inventory;

    private Rigidbody2D _rigidbody;
    private bool _canJump = true;
    private bool _canDoubleJump;
    private bool _hasUsedDoubleJump = false;

    public event Action Jumped;

    private void Awake()
    {
        _canDoubleJump = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Jumping += Jump;
        _groundDetector.OnJumpBlocked += TryJump;
        _inventory.AcquiredDoubleJump += DoubleJump;
    }

    private void OnDisable()
    {
        _playerInput.Jumping -= Jump;
        _groundDetector.OnJumpBlocked -= TryJump;
        _inventory.AcquiredDoubleJump -= DoubleJump;
    }

    private void Jump()
    {
        if (_canJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            _canJump = false;
            Jumped?.Invoke();
        }
        else if (_canDoubleJump && !_hasUsedDoubleJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            _hasUsedDoubleJump = true;
            Jumped?.Invoke();
        }
    }

    private void TryJump(bool jumpBlocked)
    {
        if (jumpBlocked)
        {
            _canJump = false;
        }
        else
        {
            _canJump = true;
            _hasUsedDoubleJump = false;
        }
    }

    private void DoubleJump()
    {
        _canDoubleJump = true;
    }
}
