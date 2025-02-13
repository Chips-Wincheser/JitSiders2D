using UnityEngine;

public class MoverMenuCamera : MonoBehaviour
{
    [SerializeField] private Transform _PositionOnMainMenu;
    [SerializeField] private Transform _PositionOnChoseLevls;
    [SerializeField] private float _speed;

    private bool _onLevls=false;
    private bool _onMenu=false;

    private void Update()
    {
        if (_onLevls)
        {
            transform.position = Vector3.Lerp(
            transform.position,
            _PositionOnChoseLevls.position,
            _speed * Time.deltaTime
            );
        }
        else if(_onMenu)
        {
            transform.position = Vector3.Lerp(
            transform.position,
            _PositionOnMainMenu.position,
            _speed * Time.deltaTime
            );
        }
    }

    public void TrasformOnLevls()
    {
        _onLevls=true;
        _onMenu=false;
    }

    public void TrasformOnMainMenu()
    {
        _onMenu=true;
        _onLevls =false;
    }
}
