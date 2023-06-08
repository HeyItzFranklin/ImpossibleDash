using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public AudioSource Music;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl.isAlive == false)
        {
            Music.Stop();

        }

        if (playerControl.MusicOn == true)
        {
            playerControl.MusicOn = false;
            Music.Play();
        }

        if (playerControl.isGod == true)
        {
            Music.pitch = 3; 
        } else
        {
            Music.pitch = 1;
        }

    }
}
