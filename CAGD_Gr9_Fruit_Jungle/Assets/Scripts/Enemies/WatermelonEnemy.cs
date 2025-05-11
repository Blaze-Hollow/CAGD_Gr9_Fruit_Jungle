using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Andrade, Maya
 * Created: 05/02/2025
 * Last Updated: 05/06/2025
 * Description: This will handle the watermelon enemy movement and attack
 */

public class WatermelonEnemy : MonoBehaviour
{
    public Transform target; //player is target so it always faces player
    public GameObject seed;
    public GameObject watermelonDrop;
    public bool dropped; 
    public int health = 20;
    public float seedShootingRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerController>().transform;

        InvokeRepeating("ShootSeeds", 0, seedShootingRate);
        dropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        if (health <= 10)
        {
            seedShootingRate = 1;
        }
        if (health <= 0)
        {
            if (dropped == false)
            {
                Instantiate(watermelonDrop, transform.position, Quaternion.identity);
                dropped = true;
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Spawn in seeds that will be aimed towards the player
    /// </summary>
    private void ShootSeeds()
    {
        GameObject newSeed = Instantiate(seed);
        newSeed.transform.position = transform.position;
        newSeed.transform.LookAt(target);
    }
}
