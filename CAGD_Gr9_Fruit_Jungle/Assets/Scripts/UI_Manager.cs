using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Andrade, Maya
 * Created: 04/24/2025
 * Last Updated: 04/24/2025
 * Description: This will handle the UI elements of the game (ex: healthbar and fruit score)
 */
public class UI_Manager : MonoBehaviour
{
    /*
     * Build Scene Order:
     * Main Menu:
     * Level:
     * Game Over:
     * Game Won:
     * Tutorial:
     */

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    //Pause Menu Buttons:

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    /// <summary>
    /// Pauses the game and sets the timescale to zero (frozen)
    /// </summary>
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //main UI buttons:

    /// <summary>
    /// When a button with this function is pressed it will take the player to the main menu scene
    /// </summary>
    public void MainMenuButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the level scene
    /// </summary>
    public void PlayButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the tutorial scene
    /// </summary>
    public void TutorialButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
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
