using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cam;
    public Transform player;
    void Start()
    {
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
