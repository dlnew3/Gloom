using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    public void PlayGame()
    {
        //StartCoroutine(LoadLevel(1));
        SceneManager.LoadScene("Iteration 4");
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Transition Animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
