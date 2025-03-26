using UnityEngine;

public class Teletort : MonoBehaviour
{
    [SerializeField] private Transform _linkedPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Mover>(out Mover player))
        {
            player.transform.position = _linkedPortal.position;
        }
    }
}