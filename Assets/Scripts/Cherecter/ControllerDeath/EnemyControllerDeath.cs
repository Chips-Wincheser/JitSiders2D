using System.Collections;
using UnityEngine;

public class EnemyControllerDeath : ControllerDeathBase
{
    protected override IEnumerator DeathAnimationEnd(float health)
    {
        Destroy(_player.gameObject);
        yield return null;
    }
}
