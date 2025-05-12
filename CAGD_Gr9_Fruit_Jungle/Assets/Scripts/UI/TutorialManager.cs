using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Andrade, Maya
 * Created: 05/09/2025
 * Last Updated: 05/12/2025
 * Description: Allows the tutorial scene to function and switch panels
 */

public class TutorialManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject playerPanel;
    public GameObject enemyPanel;
    public GameObject collectablePanel;    
   
    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(true);
        playerPanel.SetActive(false);
        enemyPanel.SetActive(false);
        collectablePanel.SetActive(false);
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
    /// When a button with this function is pressed it will take the player to the main tutorial panel
    /// </summary>
    public void BackButtonPressed()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(true);
        playerPanel.SetActive(false);
        enemyPanel.SetActive(false);
        collectablePanel.SetActive(false);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the player tutorial panel
    /// </summary>
    public void PlayerPanelButtonPressed()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
        playerPanel.SetActive(true);
        enemyPanel.SetActive(false);
        collectablePanel.SetActive(false);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the player tutorial panel
    /// </summary>
    public void EnemyPanelButtonPressed()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
        playerPanel.SetActive(false);
        enemyPanel.SetActive(true);
        collectablePanel.SetActive(false);
    }

    /// <summary>
    /// When a button with this function is pressed it will take the player to the player tutorial panel
    /// </summary>
    public void CollectablePanelButtonPressed()
    {
        Time.timeScale = 1f;
        mainMenuPanel.SetActive(false);
        playerPanel.SetActive(false);
        enemyPanel.SetActive(false);
        collectablePanel.SetActive(true);
    }
}
