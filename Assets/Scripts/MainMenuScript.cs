using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button quit;

    void Start()
    {
        Cursor.visible = true;

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            play = GameObject.Find("Canvas/Play").GetComponent<Button>();
            quit = GameObject.Find("Canvas/Quit").GetComponent<Button>();
            play.onClick.AddListener(playButton);
            quit.onClick.AddListener(quitButton);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        }

    }

    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

}
