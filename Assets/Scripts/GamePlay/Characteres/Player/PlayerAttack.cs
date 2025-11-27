using System;
using UnityEngine;

public class PlayerAttack : PlayerAttackBase
{
    [SerializeField] public int damage;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyLayers;

    public override float DamageAttack() => damage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackAnimation();
        }
    }
    public override void AttackAnimation()
    {
        animator.SetTrigger("Punch");
    }

    public void OnPunchHit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position, 
            attackRadius, 
            enemyLayers);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
