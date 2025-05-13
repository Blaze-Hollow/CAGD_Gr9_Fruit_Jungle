/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of decrease the players speed after reaching certain area]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiOilPowerUo : MonoBehaviour
{
    public int antiSpeedBoost = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {//it gets the player speed back to normal
        if(other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().speed -= antiSpeedBoost;
        }
    }
}
