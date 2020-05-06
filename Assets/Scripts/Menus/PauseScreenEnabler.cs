using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script created by Dennis to enable usage of the PauseScreen UI developed by Shane
public class PauseScreenEnabler : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        Debug.Log("PauseScreenEnabler - Releasing Cursor");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("PauseScreenEnabler - Unlocked Cursor");
        Debug.Log("lockMode = " + Cursor.lockState);
        Debug.Log("cursor visible = " + Cursor.visible);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Restart()
    {
        Debug.Log("Restarting Scene...");
        SceneManager.LoadScene("Iteration 4");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause Button Pressed.");
            if (isPaused)
            {
                Debug.Log("Resuming Game...");
                Resume();
            }
            else
            {
                Debug.Log("Pausing Game...");
                Pause();
            }
        }
    }
}
