using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Changer : MonoBehaviour
{
    public SpriteRenderer spr;
    public GameObject GameController;
    public Sprite[] sprList = new Sprite[2];

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (GameController.GetComponent<Game_Controller>().red)
        {
            spr.sprite = sprList[0];
        }
        else
        {
            spr.sprite = sprList[1];
        }
    }
}
