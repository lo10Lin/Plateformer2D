using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private MovementPlayer movePlayer;
    private Animator animator;
    [SerializeField] private JumpTrampoline[] trampoline;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        trampoline = transform.parent.GetComponentsInChildren<JumpTrampoline>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        movePlayer = collision.GetComponent<MovementPlayer>();
        rb = collision.GetComponent<Rigidbody2D>();
        player = collision.GetComponent<Transform>();

        player.Rotate(new Vector3(180, 0, 0));
        rb.gravityScale = rb.gravityScale * (-1);
        movePlayer.GravityIsChange();
        foreach (JumpTrampoline tramp in trampoline)
        {
            tramp.ReverseTrampForce();
        }
        animator.SetTrigger("collision");
    }
}
