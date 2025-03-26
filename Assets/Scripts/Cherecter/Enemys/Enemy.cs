using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimation;
    [SerializeField] private EnemyChaser _enemyChaser;

    private void OnEnable()
    {
        _enemyChaser.CameClose += OnPlayAttack;
    }

    private void OnDisable()
    {
        _enemyChaser.CameClose -= OnPlayAttack;
    }

    private void OnPlayAttack(bool isClose)
    {
        _enemyAnimation.PlayAttack(isClose);
    }
}
