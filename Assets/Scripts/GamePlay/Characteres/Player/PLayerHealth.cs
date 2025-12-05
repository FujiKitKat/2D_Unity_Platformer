using System;
using UnityEngine;

public class PLayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health;

    [SerializeField] private int timeBeforeDestroy;
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
        Console.WriteLine($"Player take {damage} damage");

        if (health <= 0)
        {
            isDead = true;
            _animator.SetTrigger("Death");
            Destroy(gameObject,timeBeforeDestroy);
        }
        
        
    }
}
