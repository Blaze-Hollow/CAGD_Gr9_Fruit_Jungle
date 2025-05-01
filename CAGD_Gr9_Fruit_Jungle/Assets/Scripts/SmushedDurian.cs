using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 04/29/2025
 * Last Updated: 04/30/2025
 * Description: This will handle the splatter effect that damages the player after if durian enemy is defeated
 */

public class SmushedDurian : MonoBehaviour
{
    public ParticleSystem Stinky;
    private bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        Stinky.GetComponent<ParticleSystem>().Play(); //plays stinky particle cloud effect
        canDamage = true;
    }

    //checks if the player collided, and damages 8hp every second the player is on it
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() && canDamage)
        {
            other.GetComponent<PlayerController>().healthPoints -= 8;
            canDamage = false;
            StartCoroutine(DamageCooldown());
        }
    }
    
    /// <summary>
    /// Ensures that the DurianSplatter doesn't do more than 8hp of damage every second
    /// </summary>
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1);
        canDamage = true;
    }


}
