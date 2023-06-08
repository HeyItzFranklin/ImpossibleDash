using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject thePauseMenu;
    bool isPaused;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            unPause();
        }



        if (isPaused == true)
        {
            Pause();


        }
        else if (isPaused == false)
        {
            unPause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        thePauseMenu.SetActive(true);
        Cursor.visible = true;

    }

    public void unPause()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        thePauseMenu.SetActive(false);
        isPaused = false;

    }
}
