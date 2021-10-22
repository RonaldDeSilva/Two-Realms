using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    //private bool turning = false;
    //private bool redEnemy = true;
    public int health;
    public bool left = true;
    public float speed;
    public Rigidbody2D rb;
    public float turnTime;
    //public GameObject GameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("turnAround");
    }

    void Update()
    {
        if (left)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    IEnumerator turnAround()
    {
        //turning = true;
        left = !left;
        yield return new WaitForSeconds(turnTime);
        StartCoroutine("turnAround");
        //turning = false;
    }

}
