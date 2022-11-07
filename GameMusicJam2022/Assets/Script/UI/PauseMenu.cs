using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject PauseMenuUI;

    private void Start()
    {
        GamePaused = false;
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
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        GamePaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        GamePaused = !GamePaused;
    }
}
