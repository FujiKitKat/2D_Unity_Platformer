using System;
using UnityEngine;

public class SceletonMovement : EnemyMovementBase
{
    public EnemyHealth enemyHealth;
    private Animator _animator;
    private Rigidbody2D _rb;
    private new void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb  = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        if (enemyHealth.isDead)
        {
            return;
        }
        
        Patrol();
    }

    public override void Patrol()
    {
        Transform target = patrolPoints[currentPoint];
        
        float direction = target.position.x - transform.position.x;
        Flip(direction);
        
        _rb.MovePosition(Vector2.MoveTowards(transform.position, 
            target.position, 
            movementSpeed * Time.deltaTime));
        
        _animator.SetFloat("SkeletonSpeed", Mathf.Abs(direction));

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            currentPoint++;
            if (currentPoint == patrolPoints.Length)
            {
                currentPoint = 0;
            }
        }
        
    }
    
    public override void ChasePlayer()
    {
        
    }
}
