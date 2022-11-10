using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public PauseMenu pauseMenu;

    public void LoadLevel(string levelName, float delay = 0f)
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resume();

        }
        StartCoroutine(LevelLoader(levelName, delay));
    }

    IEnumerator LevelLoader(string levelName, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.30f);

        SceneManager.LoadScene(levelName);
    }


}
