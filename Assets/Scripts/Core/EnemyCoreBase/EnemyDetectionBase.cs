using System;
using UnityEngine;

public abstract class EnemyDetectionBase : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] protected float detectionRadius;
    [SerializeField] protected Transform player;
    
    protected bool _isPlayerInRange;
    
    public bool IsPlayerInRange => _isPlayerInRange;
    public Transform Player => player;

    protected virtual void Awake()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    protected virtual void Update()
    {
        if (player == null)
        {
            _isPlayerInRange = false;
            return;
        }
        
        float distance = Vector2.Distance(transform.position, player.position);
        
        _isPlayerInRange = distance <= detectionRadius;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
}
