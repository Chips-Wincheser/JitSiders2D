using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 16f;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GroundChecker _groundDetector;

    private Rigidbody2D _rigidbody;
    private bool CanJump=true;

    public event Action Jumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Jumping+=Jump;
        _groundDetector.OnJumpBlocked+=TryJump;
    }

    private void OnDisable()
    {
        _playerInput.Jumping-=Jump;
        _groundDetector.OnJumpBlocked-=TryJump;
    }

    private void Jump()
    {
        if(CanJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);

            Jumped?.Invoke();
        }
    }

    private void TryJump(bool jumpBlocked)
    {
        if(jumpBlocked)
        {
            if(CanJump)
                CanJump=false;
        }
        else if (jumpBlocked==false)
        {
            CanJump=true;
        }
    }
}
