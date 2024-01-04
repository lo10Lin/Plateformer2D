using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoss : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform playerPos;
    public Transform checkHitLeft;
    public Transform checkHitRight;
    public PlayerLife playerLife;
    public LayerMask ground;
    public Vector2 dir = Vector2.zero;

    public bool isJumping;
    public bool isGrounded;
    public bool isTouch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(checkHitLeft.position, checkHitRight.position, ground);
        if (isGrounded)
        {
            isJumping = true;
        }

        dir = playerPos.position - transform.position; 

        Flip(dir.x);
        
    }

    private void FixedUpdate()
    {
        MoveBoss();
    }


    void MoveBoss()
    {
        float rnd = Random.Range(0f, 2f);
        if (rnd <= 1 && isJumping)
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
            transform.localScale = new Vector3(-10,10,0);
        }
        else if (velocity < -0.1f)
        {
            transform.localScale = new Vector3(10, 10, 0);

        }
    }

    public void ResetValue()
    {
        jumpForce = Mathf.Abs(jumpForce);
        transform.rotation = new Quaternion();
        rb.gravityScale = Mathf.Abs(rb.gravityScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerLife>(out playerLife))
        {
            PlayerLife playerLife = collision.transform.GetComponent<PlayerLife>();
            playerLife.TakeDamage(1);
        }
    }
    public void ReverseBossGravity()
    {
        jumpForce = -jumpForce;
    }
}
