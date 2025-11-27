using UnityEngine;

public abstract class EnemyMovementBase : MonoBehaviour
{

    
    [SerializeField] protected float stopDistance;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Transform[] patrolPoints;
    protected int currentPoint = 0;
    protected Transform Player;
    protected bool FacingRight = true;
    
    public abstract void Patrol();
    public abstract void ChasePlayer();

    
    protected void Flip(float direction)
    {
        if (direction > 0 && !FacingRight)
        {
            DoFlip();
        }
        
        else if (direction < 0 && FacingRight)
        {
            DoFlip();
        }
    }
    
    protected void DoFlip()
    {
        FacingRight = !FacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
