using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/02/2025
 * Last Updated: 05/06/2025
 * Description: This will handle the watermelon seeds movement and allow it to damage the player or despawn
 */

public class SeedProjectile : MonoBehaviour
{
    public int seedDamage = 5;
    public int speed = 20;
    public int seedDespawnTime = 7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnTime());
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// Despawns the seed after x amount of seconds
    /// </summary>
    IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(seedDespawnTime);
        Destroy(gameObject);
    }

    /*
     * if it collides with the player, player gets damaged
     * if it collides with anything else, nothing happens and the seed despawns
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //makes sure that if the seed overlap with themselves or any part of their models they dont cause each other to delete accidentally
        }
        else if (other.tag == "Player") 
        {
            PlayerController.healthPoints -= seedDamage;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
