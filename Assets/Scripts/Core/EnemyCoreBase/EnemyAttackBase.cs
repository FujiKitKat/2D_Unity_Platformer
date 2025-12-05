using UnityEngine;

public abstract class EnemyAttackBase : MonoBehaviour
{
    [SerializeField]protected int damage;
    [SerializeField]protected float attackRadius;
    [SerializeField]protected LayerMask playerLayer;
    [SerializeField]protected GameObject player;
    [SerializeField]protected Transform attackPoint;
    [SerializeField]protected float attackCoolDown;
    [SerializeField]protected float nextTimeAttack;
    
    public abstract void AttackAnimation();
    protected virtual void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    protected virtual void OnPunchHit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
        attackPoint.position, 
            attackRadius, 
            playerLayer);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }

}
