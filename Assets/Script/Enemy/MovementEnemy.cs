using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    public SpriteRenderer SpriteRenderer;

    private Transform target;
    private int IdTarget = 0;
    private int damageEnemy = 1;


    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            IdTarget = (IdTarget + 1) % wayPoints.Length;
            target = wayPoints[IdTarget];
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerLife playerLife = collision.transform.GetComponent<PlayerLife>();
        playerLife.TakeDamage(damageEnemy);
    }
}
