using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageEffect : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private WaitForSeconds _waitForSeconds;
    private Rigidbody2D _rigidbody;

    private Vector2 _damageForece=new Vector2(15,10);

    private int _numberTransfusions = 2;
    private float _delay = 0.5f;
    private bool _isTakingDamage = false;
    private float _direction;


    private void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _waitForSeconds = new WaitForSeconds(_delay);
    }
    public void PlayDamageEffect(Transform position)
    {
        if (!_isTakingDamage)
        {
            _isTakingDamage = true;
            _direction = Mathf.Sign(position.position.x - transform.position.x);
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(_damageForece.x*-_direction, _damageForece.y), ForceMode2D.Impulse);


            StartCoroutine(ChangeColorTemporarily());
        }
    }

    private IEnumerator ChangeColorTemporarily()
    {
        for (int i = 0; i < _numberTransfusions; i++)
        {
            _spriteRenderer.color = Color.red;
            yield return _waitForSeconds;
            _spriteRenderer.color = Color.white;
            yield return _waitForSeconds;
        }

        _isTakingDamage = false;
    }
}