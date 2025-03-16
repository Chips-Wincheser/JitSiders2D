using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Messege : MonoBehaviour
{
    [SerializeField] private Mover _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Button _button;
    [SerializeField] private string _messegeText;

    private WaitForSeconds _waitForSeconds;
    private float _delay=0.1f;
    private TextMeshProUGUI _buttonText;

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        _buttonText = _button.GetComponentInChildren<TextMeshProUGUI>();

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
            _button.gameObject.SetActive(true);
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector2.zero;
            _player.enabled = false;

            StartCoroutine(ShowText());
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

    private IEnumerator ShowText()
    {
        for (int i = 0; i < _messegeText.Length; i++)
        {
            _buttonText.text+=_messegeText[i];
            yield return _waitForSeconds;
        }
    }
}
