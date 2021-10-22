using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public bool red = true;
    public GameObject curCheckPoint;
    public GameObject PlayerPreFab;
    public AudioClip[] sounds = new AudioClip[6];
    public AudioSource audio;

    public void PlayEnemy()
    {
        audio.PlayOneShot(sounds[0], 1f);
    }
    public void PlayJump()
    {
        audio.PlayOneShot(sounds[1], 1f);
    }
    public void PlayJump1()
    {
        audio.PlayOneShot(sounds[2], 1f);
    }
    public void PlayLanding()
    {
        audio.PlayOneShot(sounds[4], 1f);
    }
    public void PlayTorch()
    {
        audio.PlayOneShot(sounds[5], 1f);
    }
}
