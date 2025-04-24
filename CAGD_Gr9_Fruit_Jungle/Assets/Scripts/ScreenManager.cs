using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Andrade, Maya
 * Created: 04/24/2025
 * Last Updated: 04/24/2025
 * Description: This will handle all the scene switching in the game as well as pausing
 */
public class ScreenManager : MonoBehaviour
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

    private void SetBarMax()
    {
        
    }

    private void SetBarPos()
    {

    }
}
