using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private float timeBeforeDestroy;
    private Animator _animator;

    public bool isDead { get; private set; }


private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

public void TakeDamage(int damage)
{
    if (isDead)
    {
        return;
    }
    
    health -= damage;
    Console.WriteLine($"Enemy health is {health}");
        
        if (health <= 0)
        {
            isDead = true;
            _animator.SetTrigger("Death");
            Destroy(gameObject, timeBeforeDestroy);
        }
    }
}
