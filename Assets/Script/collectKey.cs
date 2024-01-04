
using UnityEngine;

public class collectKey : MonoBehaviour
{
    public BoxCollider2D door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.isTrigger = true;
        Destroy(gameObject);
        
    }
}
