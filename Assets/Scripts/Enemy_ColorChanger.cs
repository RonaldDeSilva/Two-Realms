using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ColorChanger : MonoBehaviour
{
    public GameObject GameController;
    public bool redEnemy;

    void Start()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("Game Controller");
        }
    }
    
    void Update()
    {
        if (GameController.GetComponent<Game_Controller>().red != redEnemy)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
