using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour

{
    [SerializeField] AudioSource sfx;
    bool gameOver;
    bool paused;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
            ResumeGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void ResumeGame()
    {
        paused = false;
        Camera.main.GetComponent<AudioSource>().Play();

        Time.timeScale = 1;
    }
}
