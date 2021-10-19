using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public int health = 2;
    public Rigidbody2D rb;
    public GameObject GameController;
    public bool jumping = false;
    public bool aPress = false;
    public bool dPress = false;
    public bool jPress = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKey(KeyCode.SpaceBar))
        {
            jPress = true;
        }
        else { dPress = false; }
    }

    void FixedUpdate()
    {
        
        float hAdd = 0f;
        float vAdd = 0f;

        if (dPress == true) { hAdd += speed; }
        if (aPress == true) { hAdd -= speed; }

        rb.velocity = new Vector2(hAdd, vAdd);
    }
}
