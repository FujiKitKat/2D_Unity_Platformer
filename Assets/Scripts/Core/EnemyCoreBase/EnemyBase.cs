using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public abstract float Damage();
    public abstract float MoveSpeed();
    public abstract float DecectionRange();
    public abstract float AttackRange();
}
