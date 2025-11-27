using UnityEngine;

public abstract class PlayerMovementBase : MonoBehaviour
{
    public abstract float GetSpeed();
    public abstract float GetJumpForce();
    public abstract void Move();
    public abstract void Jump();
}
