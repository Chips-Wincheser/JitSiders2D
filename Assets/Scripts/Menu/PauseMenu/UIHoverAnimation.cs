using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private Animator _animator;

    private void Awake()
    {
        _animator.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.enabled = false;
    }
}
