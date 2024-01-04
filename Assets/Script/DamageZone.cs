using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public bool iscollide = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        iscollide = true;
        PlayerLife playerLife = collision.transform.GetComponent<PlayerLife>();
        playerLife.TakeDamage(1);
    }
}
