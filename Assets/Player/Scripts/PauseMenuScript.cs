using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenuScript : MonoBehaviour
{
    /// <summary>
    /// pause the game when you toggle escape
    /// and display the pause menu when you are paused so we can quit
    /// 
    /// </summary>

    public GameObject pauseMenuPanel;
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            SetPausedState(paused);
        }
    }


    void SetPausedState(bool state)
    {
        pauseMenuPanel.SetActive(state);
        SetCursorVisible(state);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //sets the sursor and pause state
    private void OnEnable()
    {
        SetCursorVisible(false);
        SetPausedState(paused);
    }

    void SetCursorVisible(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }

}
