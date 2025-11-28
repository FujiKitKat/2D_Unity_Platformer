using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SceletonMovement : EnemyMovementBase
{
    public EnemyHealth enemyHealth;
    private Animator _animator;
    private Rigidbody2D _rb;
    
    [SerializeField] private EnemyDetectionBase _detection;
    private new void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb  = GetComponent<Rigidbody2D>();
        enemyHealth = GetComponent<EnemyHealth>();

        if (_detection == null)
        {
            _detection = GetComponent<EnemyDetectionBase>();
        }
    }

    private void FixedUpdate()
    {
        if (enemyHealth != null && enemyHealth.isDead)
            return;

        if (_detection != null && _detection.IsPlayerInRange && _detection.Player != null)
        {
            ChasePlayer(_detection.Player);
        }
        else
        {
            Patrol();
        }
    }

    public override void Patrol()
    {
        Transform target = patrolPoints[CurrentPoint];
        
        float direction = target.position.x - transform.position.x;
        Flip(direction);
        
        _rb.MovePosition(Vector2.MoveTowards(transform.position, 
            target.position, 
            movementSpeed * Time.fixedDeltaTime));
        
        _animator.SetFloat("SkeletonSpeed", Mathf.Abs(direction));

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            CurrentPoint++;
            if (CurrentPoint == patrolPoints.Length)
            {
                CurrentPoint = 0;
            }
        }
    }
    
    public override void ChasePlayer(Transform player)
    {
        if (player != null && _rb != null)
        {
            Vector2 toPlayer = (Vector2)player.position - _rb.position;
            float dirX = toPlayer.x;
            Flip(dirX);
            
            Vector2 direction = toPlayer.normalized;
            float step =  movementSpeed * Time.fixedDeltaTime;
            Vector2 newPosition = _rb.position + direction * step;
            _rb.MovePosition(newPosition);
            
            _animator.SetFloat("SkeletonSpeed", Mathf.Abs(dirX));
        }
    }
}
