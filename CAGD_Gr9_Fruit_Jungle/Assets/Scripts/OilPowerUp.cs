/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of increasing the players speed for certain areas of the game]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPowerUp : MonoBehaviour
{
    public int speedBoost = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {//it increases the player speed when interact with it and destroys the pick up
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().speed += speedBoost;
            Destroy(gameObject);
        }
    }
}
