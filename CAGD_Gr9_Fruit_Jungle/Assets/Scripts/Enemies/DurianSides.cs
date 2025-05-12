using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/08/2025
 * Last Updated: 05/08/2025
 * Description: This makes the durian damage player if the player collides (not crushed) with the durian
 */
public class DurianSides : MonoBehaviour
{
    //when the player collides with the side of the durian, it takes 15hp of damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.healthPoints -= 15;
        }
    }
}
