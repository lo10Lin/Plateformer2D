using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpot : MonoBehaviour
{
    public float respawnTime;
    public Transform respawn;

    private float time;

    [SerializeField] private bool isKill;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform enemy;
    [SerializeField] private BoxCollider2D[] boxCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
        enemy = transform.parent.GetComponentInParent<Transform>();
        boxCollider2D = GetComponentsInParent<BoxCollider2D>();
    }

    private void Start()
    {
        time = respawnTime;
        isKill = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        isKill = true;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
        EnableAndDisableClass();
    }   

    private void EnableAndDisableClass()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
        animator.enabled = !animator.enabled;
        foreach (BoxCollider2D box in boxCollider2D)
        {
            box.enabled = !box.enabled;
        }
    }

    private void Update()
    {
        if (isKill)
        {
            respawnTime -= Time.deltaTime;
            if(respawnTime <= 0)
            {
                enemy.position = respawn.position;
                EnableAndDisableClass();
                respawnTime = time;
                isKill = false;
            }
        }
    }
}
