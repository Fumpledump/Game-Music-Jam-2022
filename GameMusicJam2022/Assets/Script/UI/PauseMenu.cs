using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject PauseMenuUI;

    private Timer timer;

    private void Start()
    {
        GamePaused = false;

        timer = Timer.instance;
    }

    public void Update()
    {
        if (GamePaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        GamePaused = false;
        PauseMenuUI.SetActive(false);
        timer.ShowTimer(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        GamePaused = true;
        PauseMenuUI.SetActive(true);
        timer.ShowTimer(true);
        Time.timeScale = 0f;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        GamePaused = !GamePaused;
    }
}
