using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChicken : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerLife playerLife;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float speed;
    public bool ismove = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Transform>();
            ismove = true;
            animator.SetFloat("Speed", 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetFloat("Speed", 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ismove = false;
        animator.SetFloat("Speed", -1);
    }

    private void FixedUpdate()
    {
        if (ismove)
        {
            MoveChicken();
        }
    }
    void MoveChicken()
    {
        float dir = Mathf.Sign(player.position.x  - transform.position.x);
        Vector2 move = new Vector2(dir * speed, 0f);

        spriteRenderer.flipX = (dir > 0) ? true : false;
        transform.Translate(move * Time.fixedDeltaTime, Space.World);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerLife>(out playerLife))
        {
            playerLife.TakeDamage(1);
            ismove = false;
        }
    }

}
