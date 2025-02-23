using UnityEngine;

public class Messege : MonoBehaviour
{
    [SerializeField] private Mover _player;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        _inventory.IsPicked+=SendMessege;
    }

    private void OnDisable()
    {
        _inventory.IsPicked-=SendMessege;
    }

    private void SendMessege()
    {
        if(_inventory.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector2.zero;
            _player.enabled = false;
        }
    }

    public void RemoveMessege()
    {
        if (_inventory.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            _player.enabled = true;
            rigidbody.isKinematic = false;
        }
    }
}
