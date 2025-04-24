using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/*
 * Author: Andrade, Maya
 * Created: 04/24/2025
 * Last Updated: 04/24/2025
 * Description: This will handle the UI elements of the game (ex: healthbar and fruit score)
 */
public class UI_Manager : MonoBehaviour
{
    [Header("Health Bar Variables")]
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMP_Text healthPoints_Text;
    public PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        SetBarMax();
    }

    // Update is called once per frame
    void Update()
    {
        SetBarPos();
    }

    /// <summary>
    /// Sets the maximum vaulue of the healthbar and makes it green at the start
    /// </summary>
    private void SetBarMax()
    {

    }

    /// <summary>
    /// Keeps the slider updated so that it reflects the player's current HP value
    /// </summary>
    private void SetBarPos()
    {

    }

}
