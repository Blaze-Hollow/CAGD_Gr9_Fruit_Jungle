using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Andrade, Maya
 * Created: 04/24/2025
 * Last Updated: 05/01/2025
 * Description: This will handle all pausing and resuming during gameplay
 */

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false); //make sure pause menu isn't open on start accidentally
        gameIsPaused = false; //make sure the game doesn't think it should be paused for some reason
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Resumes the game and sets the timescale back to normal (not frozen)
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    /// <summary>
    /// Pauses the game and sets the timescale to zero (frozen)
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the main menu scene
    /// </summary>
    public void MainMenuButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When a button with this function is pressed it will close out the application (or print that the player has quit in console if not a build)
    /// </summary>
    public void QuitButtonPressed()
    {
        print("Player has quit the game");
        Application.Quit();
    }
}
