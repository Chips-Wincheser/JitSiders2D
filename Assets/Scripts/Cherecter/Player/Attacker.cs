using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField]private Collider2D _collision;

    private void OnEnable()
    {
        _playerInput.Attaked+=Attack;
    }

    private void OnDisable()
    {
        _playerInput.Attaked-=Attack;
    }

    private void Awake()
    {
        ToblerColision(false);
    }

    private void Attack()
    {
        ToblerColision(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            if (_damage>0)
            {
                health.TakeDamage(_damage);

                if (collision.TryGetComponent<DamageEffect>(out DamageEffect damageEffect))
                {
                    damageEffect.PlayDamageEffect(transform);
                }
            }
        }

        ToblerColision(false);
    }

    private void ToblerColision(bool isEnable)
    {
        _collision.enabled = isEnable;
    }
}