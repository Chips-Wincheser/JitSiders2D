using UnityEngine;

public class ParticleHit : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnParticleCollision(GameObject other)
    {
        _health.TakeDamage(10);
    }
}
