using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrampoline : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float jumpForce;
    private Animator animator;
    [SerializeField] private bool isTouch;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        isTouch = true;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isTouch)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            animator.SetTrigger("colliderPlayer");
            isTouch = false;
        }
    }

    public void ReverseTrampForce ()
    {
        jumpForce = -jumpForce;
    }
}
