using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public PauseMenu pauseMenu;

    private AudioManager audioManager;
    private Timer timer;

    public void Start()
    {
        audioManager = AudioManager.instance;
        timer = Timer.instance;
    }

    public void LoadLevel(string levelName, float delay = 0f)
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resume();

        }

        StartCoroutine(LevelLoader(levelName, delay));
    }

    public void LoadLevelEvent(string levelName)
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resume();

        }
        StartCoroutine(LevelLoader(levelName));
    }

    IEnumerator LevelLoader(string levelName, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log(levelName + " was loaded");

        // Level Set Up
        switch (levelName)
        {
            case "Menu":
                timer.EndTimer();
                timer.ShowTimer(false);
                audioManager.ChangeTrack("Village");
                break;
            case "Level 1":
                timer.BeginTimer();
                break;
            case "Level 2":
                audioManager.ChangeTrack("Overworld");
                break;
            case "Level 3":
                timer.EndTimer();
                audioManager.ChangeTrack("Win");
                break;
            default:
                audioManager.ChangeTrack("Village");
                break;
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.30f);

        SceneManager.LoadScene(levelName);
    }


}
