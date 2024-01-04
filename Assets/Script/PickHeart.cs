using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHeart : MonoBehaviour
{
    private PlayerLife life;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        life = collision.GetComponent<PlayerLife>();
        EnableAndDisableClass();
        life.AddHeart(1);

    }

    private void EnableAndDisableClass()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
        animator.enabled = !animator.enabled;
        boxCollider2D.enabled = !animator.enabled;
    }


}
