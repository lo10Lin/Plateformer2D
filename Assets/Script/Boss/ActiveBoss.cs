using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public GameObject[] boss;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < boss.Length; i++)
        {
            boss[i].SetActive(true);
        }
    }
}
