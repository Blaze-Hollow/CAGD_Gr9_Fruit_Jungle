using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Fruit Score")]
    public TMP_Text fruitScore_Text;

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
        slider.maxValue = playerScript.maxHealthPoints; //sets slider's maximum value
        slider.value = playerScript.maxHealthPoints; //sets the slider's value at full HP at start
        fill.color = gradient.Evaluate(1f); //sets the color to green
        healthPoints_Text.text = playerScript.healthPoints + ""; //sets the HP text on the side to the player's HP value at start
    }

    /// <summary>
    /// Keeps the slider updated so that it reflects the player's current HP value
    /// </summary>
    private void SetBarPos()
    {
        slider.value = playerScript.healthPoints; //keeps the slider's vaue synced with player's HP value
        fill.color = gradient.Evaluate(slider.normalizedValue); //changes the color of the health bar fill as it lowers
        healthPoints_Text.text = playerScript.healthPoints + ""; //keeps the HP number displayed synced with the player's HP value
    }

}
