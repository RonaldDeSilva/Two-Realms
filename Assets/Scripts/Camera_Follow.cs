using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public GameObject Player;
    public float camSpd;

    void Update()
    {

        Vector3 diff = new Vector3((Player.transform.position.x - transform.position.x) * Time.deltaTime * camSpd, (Player.transform.position.y - transform.position.y) * Time.deltaTime * camSpd, 0);
        transform.position = transform.position + diff;
    }
}
