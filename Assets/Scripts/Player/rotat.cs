using UnityEngine;

public class rotat : MonoBehaviour
{
    private Quaternion _rotatedState;
    private Quaternion defaultState;

    private void Awake()
    {
        _rotatedState=Quaternion.Euler(0, 180, 0);
        defaultState=Quaternion.Euler(0, 0, 0);
    }

    public void Rotate(float direction)
    {
        if (direction < 0)
        {
            transform.rotation = _rotatedState;
        }
        else if (direction > 0)
        {
            transform.rotation = defaultState;
        }
    }
}
