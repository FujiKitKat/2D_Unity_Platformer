using System;
using UnityEngine;

public class PlayerMovement : PlayerMovementBase
{
    private float _horizontalMove;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    [SerializeField] 
    private Animator animator;
    [SerializeField] 
    private LayerMask groundLayer;
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private float jumpForce;
    [SerializeField]
    private float distanceToTheGround;
    [SerializeField] 
    private bool facingRight = true;
    [SerializeField] 
    private bool jumpRequest;
    
    public override float GetSpeed() => speed;
    public override float GetJumpForce() => jumpForce;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator =  GetComponent<Animator>();
    }
    private void Update()
    {
        _isGrounded = IsGrounded();
        _horizontalMove = Input.GetAxis("Horizontal") * GetSpeed();
        Jump();
        FlipCheck();
        animator.SetFloat("Run", Math.Abs(_horizontalMove));
    }
    private void FixedUpdate()
    {
        Move();

        if (jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * GetJumpForce(), ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }
    
    public override void Move()
    {
        Vector2 movement = new Vector2(_horizontalMove, _rigidbody2D.linearVelocity.y);
        _rigidbody2D.linearVelocity = movement;
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            jumpRequest = true;
            animator.SetTrigger("Jump");
        }
    }
    
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, 
            Vector2.down * distanceToTheGround, 
            Color.red);
        
        return Physics2D.Raycast(transform.position, 
            Vector2.down, 
            distanceToTheGround,
            groundLayer);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FlipCheck()
    {
        if (_horizontalMove < 0 && facingRight)
        {
            Flip();
        }

        if (_horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
    }
}
