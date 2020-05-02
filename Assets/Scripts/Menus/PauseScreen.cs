using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreenUI; //[SerializeField]
    public bool isPaused; //[SerializeField]

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseScreenUI.SetActive(true);
                Time.timeScale = 1f;
            }
        }

    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
