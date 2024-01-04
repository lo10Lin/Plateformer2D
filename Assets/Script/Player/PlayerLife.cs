using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int maxHeart = 5;
    public int currentHeart;
    private bool isFlash = false;

    public ManageLifePlayer lifePlayer;
    public SpriteRenderer graphics;
    public Transform player;
    public Transform respawn;
    private MovementPlayer move;
    private Rigidbody2D rb;
    public GameObject zone2;
    private JumpTrampoline[] tramp;


    // Start is called before the first frame update
    void Start()
    {
        currentHeart = maxHeart;
        lifePlayer.SetHeart(currentHeart);
        graphics = GetComponent<SpriteRenderer>();
        player = GetComponent<Transform>();
        move = GetComponent<MovementPlayer>();
        rb = GetComponent<Rigidbody2D>();
        tramp = zone2.GetComponentsInChildren<JumpTrampoline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHeart <= 0 )
        {
            SceneManager.LoadScene(3);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHeart -= damage;
        lifePlayer.SetHeart(currentHeart);
        if (rb.gravityScale < 0)
        {
            ResetValue();
        }
        player.position = respawn.position;
        isFlash = true;
        StartCoroutine(BlinkPlayer(.10f));

    }

    private void ResetValue()
    {
        move.GravityIsChange();
        foreach (JumpTrampoline trampoline in tramp)
        {
            trampoline.ReverseTrampForce();
        }
        player.Rotate(new Vector3(180, 0, 0));
        rb.gravityScale = rb.gravityScale * (-1);
    }

    public void AddHeart(int heal)
    {
        currentHeart += heal;
        lifePlayer.SetHeart(currentHeart);
    }

    public IEnumerator BlinkPlayer(float flashDelay)
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
