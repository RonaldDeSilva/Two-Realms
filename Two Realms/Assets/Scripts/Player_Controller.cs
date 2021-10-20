using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Player Stats
    public int health;
    public float speed;
    public float jumpHeight;
    #endregion
    #region GC and RB
    public Rigidbody2D rb;
    public GameObject GameController;
    public SpriteRenderer spr;
    #endregion
    #region Bools
    public bool jumping = false;
    public bool aPress = false;
    public bool dPress = false;
    public bool jPress = false;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (Input.GetKey("a"))
        {
            aPress = true;
        }
        else { aPress = false; }
        if (Input.GetKey("d"))
        {
            dPress = true;
        }
        else { dPress = false; }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aPress = true;
        }
        else { aPress = false; }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dPress = true;
        }
        else { dPress = false; }

        if (!jumping)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                jPress = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameController.GetComponent<Game_Controller>().red = !GameController.GetComponent<Game_Controller>().red;
        }

    }

    void FixedUpdate()
    {
        if (GameController.GetComponent<Game_Controller>().red)
        {
            spr.color = Color.red;
        }
        else
        {
            spr.color = Color.blue;
        }
        
        
        float hAdd = 0f;

        Vector3 jump = new Vector3(0, jumpHeight, 0);

        if (dPress == true) { hAdd += speed; }
        if (aPress == true) { hAdd -= speed; }

        rb.velocity = new Vector2(hAdd, rb.velocity.y);

        if (jPress) {
            rb.AddForce(jump);
            jPress = false;
            jumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        jumping = false;
    }

}
