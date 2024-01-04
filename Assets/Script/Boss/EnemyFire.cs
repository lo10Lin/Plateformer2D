using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject Ball;
    [SerializeField] private MovementBoss bossMove;
    public int force;
    public float rnd;
    // Start is called before the first frame update
    void Start()
    {
        bossMove = GetComponentInParent<MovementBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
            StartCoroutine(fire());
            //Bullet.GetComponent<Bullet>().initValue(bossMove, force);

        
    }
    public IEnumerator fire()
    {
        rnd = Random.Range(0f, 100f);
        if (rnd <= .5f)
        {
            bossMove.dir.Normalize();
            GameObject Bullet = Instantiate(Ball, transform.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().velocity = bossMove.dir * force * Time.deltaTime;
            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
