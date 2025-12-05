using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected abstract float Damage();
    protected abstract float MoveSpeed();
    protected abstract float DecectionRange();
    protected abstract float AttackRange();
}
