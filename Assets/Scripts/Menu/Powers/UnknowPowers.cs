using UnityEngine;

public class UnknowPowers : MonoBehaviour
{
    [SerializeField] private string _powerType;
    
    private bool _canUsePower;

    private void OnEnable()
    {
        _canUsePower=(PlayerPrefs.GetInt(_powerType)!=0);

        if (_canUsePower )
        {
            gameObject.SetActive(!_canUsePower);
        }
    }
}
