using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public PauseMenu pauseMenu;

    public void LoadLevel(string levelName)
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resume();

        }
        StartCoroutine(LevelLoader(levelName));
    }

    IEnumerator LevelLoader(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.30f);

        SceneManager.LoadScene(levelName);
    }


}
