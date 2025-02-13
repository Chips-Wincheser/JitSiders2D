using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyBird : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Rigidbody2D _rigidbody2D;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(10);
        if (gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
            _rigidbody2D = rigidbody2D;
    }

    private void Start()
    {
        StartCoroutine(Fly());
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(-5,0 );
    }

    private IEnumerator Fly()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return _waitForSeconds;
            transform.position =_transform.position;
        }
    }
}
