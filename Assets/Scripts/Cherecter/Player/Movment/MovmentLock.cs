using UnityEngine;

public class MovmentLock : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;

    private void OnEnable()
    {
        _playerInput.Attaked += () => HandleMovement(gameObject);
    }

    private void OnDisable()
    {
        _playerInput.Attaked -= () => HandleMovement(gameObject);
    }

    public static void HandleMovement(GameObject obj,bool isDead=false)
    {
        if (obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            if (obj.TryGetComponent<Jumper>(out Jumper jumper))
            {
                jumper.enabled = false;

                if(isDead)
                    rigidbody.bodyType = RigidbodyType2D.Static;
                else
                    rigidbody.bodyType = RigidbodyType2D.Dynamic;
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                
                jumper.enabled = true;
            }
        }
    }
}
