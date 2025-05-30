/* Author [Diaz,Samuel]
 * Last Updated [04/24/2025]
 * Description [This script is in charge of increasing the players strenght after they collide with the object]
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrenghtPowerUp : MonoBehaviour
{
    public int strenghtBoost = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {//this changes the player strenght once they interact with it and destroys the pick up
     // it wasn't use
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().attackStrength += strenghtBoost;

            Destroy(gameObject);
        }
    }
}
