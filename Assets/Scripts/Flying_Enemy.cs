using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Enemy : MonoBehaviour
{
    //private bool turning = false;
    //private bool redEnemy = true;
    public int health;
    public bool left = true;
    public float speedy;
    public float speedx;
    public Rigidbody2D rb;
    //public GameObject GameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        if (turn)
        {
            StartCoroutine("turnAround");
            turn = false;
        }

        if (!turning)
        {
            if (GameController.GetComponent<Game_Controller>().red == redEnemy)
            {
                turn = true;
            }
        }
        */

        if (left)
        {
            rb.velocity = new Vector3(-speedx, speedy, 0);
        }
        else
        {
            rb.velocity = new Vector3(speedx, -speedy, 0);
        }


    }

    IEnumerator turnAround()
    {
        //turning = true;
        left = !left;
        yield return new WaitForSeconds(0.5f);
        //turning = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Turn"))
        {
            StartCoroutine("turnAround");
        }
    }
}
