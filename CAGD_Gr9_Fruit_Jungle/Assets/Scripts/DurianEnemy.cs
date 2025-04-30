using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Andrade, Maya
 * Created: 04/29/2025
 * Last Updated: 04/29/2025
 * Description: This will handle the durian enemy movement and attack
 */

public class DurianEnemy : MonoBehaviour
{
    public int speed = 10;
    public int health = 10;
    private bool hasExploded = false;
    public GameObject DurianSplatter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 && !hasExploded)
        {
            Instantiate(DurianSplatter, transform.position, transform.rotation);
        }
    }
}
