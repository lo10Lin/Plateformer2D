using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakZone : MonoBehaviour
{
    private BossLife boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponentInParent<BossLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boss.TakeDamage(1);
    }

}
