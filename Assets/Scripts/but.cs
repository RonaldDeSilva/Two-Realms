using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class but : MonoBehaviour
{

    public void OnButtonPress()
    {
        SceneManager.LoadScene("Level 1");
    }
}
