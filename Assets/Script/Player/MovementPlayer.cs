using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed;
    public float speedInJump;
    public float jumpForce;
    
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask ground;

    public bool isJumping;
    public bool isGrounded;
    public bool canDoubleJump;
    float moveHorizontal;


    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        speedInJump = moveSpeed /3;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position,ground);
        //animator.SetBool("isGrounded", true);
        if (isJumping)
        {
            moveHorizontal = Input.GetAxis("Horizontal") * speedInJump * Time.fixedDeltaTime;
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        }

        if (isGrounded)
        {
            canDoubleJump = true;
        }
        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded)
            {
                isJumping = true;
            }
            else if (canDoubleJump)
            {
                isJumping = true;
                canDoubleJump = false;
            }
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Speed", characterVelocity);
    }

    private void FixedUpdate()
    { 
        MovePlayer(moveHorizontal);
    }

    
    void MovePlayer(float horizontal)
    {
        Vector3 target = new Vector2(horizontal, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref velocity, 0.03f);

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);    
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void GravityIsChange()
    {
        jumpForce = -jumpForce;
    }
}
