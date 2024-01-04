using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBossGravity : MonoBehaviour
{
    public float reverseTime;
    public GameObject boss;
    private Animator animator;
    private Rigidbody2D rb;
    private Transform transform;
    private MovementBoss move;
    private BossLife life;
    [SerializeField] private float timer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = boss.GetComponent<Rigidbody2D>();
        transform = boss.GetComponent<Transform>();
        move = boss.GetComponent<MovementBoss>();
        life = boss.GetComponent<BossLife>();
    }

    private void Update()
    {
        if (timer < 0)
        {
            timer = 0;
            move.ResetValue();
        }
        else if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = 0;
        transform.Rotate(new Vector3(180, 0, 0));
        rb.gravityScale *=  (-1);
        move.ReverseBossGravity();
        animator.SetTrigger("collision");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = reverseTime;
    }
}
