using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Author: Andrade, Maya
 * Created: 04/24/2025
 * Last Updated: 05/01/2025
 * Description: This will handle all the scene switching in the game
 */

public class ScreenManager : MonoBehaviour
{
    /*
     * Build Scene Order
     * Main Menu: 0
     * Level One: 1
     * Level Two: 2
     * Level Three: 3
     * Game Over: 4
     * Game Won: 5
     * Tutorial: 6
     */


    /// <summary>
    /// When a button with this function is pressed it will take the player to the main menu scene
    /// </summary>
    public void MainMenuButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the first level scene
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
        SceneManager.LoadScene(6);
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
