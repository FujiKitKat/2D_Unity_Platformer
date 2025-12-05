using UnityEngine;

public class WolfAttack : EnemyAttackBase
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= attackRadius && Time.time >= nextTimeAttack)
        {
            AttackAnimation();
            nextTimeAttack = Time.time + attackCoolDown;
        }
    }
    
    public override void AttackAnimation()
    {
        _animator.SetTrigger("WolfAttack");
    }

    protected override void OnPunchHit()
    {
        base.OnPunchHit();
    }
}
