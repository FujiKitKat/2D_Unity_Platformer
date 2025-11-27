using UnityEngine;

public class WolfHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBeforeDestroy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetTrigger("DeathWolf");
            Destroy(gameObject,timeBeforeDestroy);
        }
    }
}
