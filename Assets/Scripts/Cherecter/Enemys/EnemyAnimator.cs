using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{ 
    [SerializeField] private Animator _animator;

    private int _isAttack = Animator.StringToHash("IsAttack");

    public void PlayAttack(bool isFarAway)
    {
        _animator.SetBool(_isAttack, isFarAway);
    }
}
