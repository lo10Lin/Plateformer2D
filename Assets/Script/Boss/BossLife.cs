using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLife : MonoBehaviour
{
    public int maxHeart = 5;
    public int currentHeart;
    private bool isFlash = false;

    public SpriteRenderer graphics;
    public Transform player;
    public Transform[] respawn;
    [SerializeField] private Transform[] test;
    [SerializeField] private MovementBoss move;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Awake()
    {
        currentHeart = maxHeart;
        test = GetComponentsInParent<Transform>(); 
        graphics = GetComponent<SpriteRenderer>();
        move = GetComponent<MovementBoss>();
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move.isTouch)
        {
            TakeDamage(1);
        }
        if (currentHeart <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isFlash)
        {
            currentHeart -= damage;
            if (rb.gravityScale < 0)
            {
                move.ResetValue();
            }
            player.position = respawn[(int)Random.Range(0f,3f)].position;
            isFlash = true;
            StartCoroutine(BlinkBoss(.10f));
        }
    }



    public IEnumerator BlinkBoss(float flashDelay)
    {
        while (isFlash)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSecondsRealtime(flashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSecondsRealtime(flashDelay);
            StartCoroutine(HandleBlinkDelay());
        }
    }

    public IEnumerator HandleBlinkDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        isFlash = false;
    }
}
