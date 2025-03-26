using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode CodeKey = KeyCode.Space;
    private const string Horizontal = "Horizontal";

    private bool _isJump;

    public bool IsMovementLock=false;//регулируется из аниматора

    public event Action Jumping;
    public event Action<float> Runing;
    public event Action<float> PlayerStanding;
    public event Action Attaked;

    private void Update()
    {
        if (Input.GetKeyDown(CodeKey) && IsMovementLock==false)
        {
            _isJump = true;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            MovmentLock.HandleMovement(gameObject);
            Attaked?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(IsMovementLock==false)
        {
            float horizontal = Input.GetAxisRaw(Horizontal);

            Runing?.Invoke(horizontal);

            if (horizontal == 0)
            {
                PlayerStanding?.Invoke(horizontal);
            }
        }
    }

    private void HandleJump()
    {
        if (IsMovementLock==false)
        {
            if (_isJump)
            {
                Jumping?.Invoke();
                _isJump= false;
            }
        }
    }
}