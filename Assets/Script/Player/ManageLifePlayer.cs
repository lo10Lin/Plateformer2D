using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageLifePlayer : MonoBehaviour
{
    private Image[] life;
    private int maxLife = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        life = GetComponentsInChildren<Image>();
    }
    void Start()
    {

    }

    private void Update()
    {

    }
    // Update is called once per frame
    public void SetHeart(int currentHeart)
    {
        for (int i = 0; i < maxLife; i++)
        {
            if (i < currentHeart)
            {
                life[i].enabled = true;
            }
            else
            {
                life[i].enabled = false;
            }
        }
    }

}

