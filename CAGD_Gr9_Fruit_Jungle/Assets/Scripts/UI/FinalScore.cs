using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * Author: Andrade, Maya
 * Created: 05/13/2025
 * Last Updated: 05/13/2025
 * Description: Allows the final score to be displayed
 */

public class FinalScore : MonoBehaviour
{

    public TMP_Text finalScore;
    public PlayerController playerScript;


    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = "Final Score: " + PlayerController.fruitScore.ToString();
    }
}
