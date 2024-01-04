using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform respawnPos;
    private Transform checkpointPos;

    private void Awake()
    {
        checkpointPos = GetComponent<Transform>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        respawnPos.position = checkpointPos.position;
    }
}
