using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _isRun = Animator.StringToHash("IsRun");
    private int _isAttack = Animator.StringToHash("IsAttack");

    public void Run(bool isRuning)
    {
        _animator.SetBool(_isRun, isRuning);
    }

    public void Attack(bool isAttacking)
    {
        _animator.SetBool(_isAttack, isAttacking);
    }
}
